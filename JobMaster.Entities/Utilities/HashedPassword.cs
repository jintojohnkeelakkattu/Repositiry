// Copyright (c) 2017 FarmVipani, Inc. All rights reserved.

using System;
using System.Text;


namespace JobMaster
{
	/// <summary>
	/// A hashed password - i.e. a salt value, and the value that results from hashing the salt
	/// together with the password string.
	/// </summary>
	public class HashedPassword
	{
		/// <summary>
		/// Creates a new instance with already-known salt and hash values.
		/// Use this constructor when you're loading a hashed password from the database
		/// in order to check a given password string, such as during login.
		/// </summary>
		public HashedPassword(string salt, string hash, int hashVersion)
		{
			this.Salt = salt;
			this.Hash = hash;
			this.HashVersion = hashVersion;
		}

		/// <summary>
		/// Creates a new instance from a password string.
		/// Use this constructor to create new salt and hash values ready for storage in the database,
		/// such as when creating a new user or executing a password change.
		/// </summary>
		public HashedPassword(string password, int hashVersion)
		{
			this.Salt = CreateSalt();
			this.Hash = CreateHash(password, this.Salt, hashVersion);
			this.HashVersion = hashVersion;
		}

		/// <summary>
		/// The salt, either from the value passed to the constructor, or generated internally.
		/// </summary>
		public string Salt { get; private set; }

		/// <summary>
		/// The hash, either from the value passed to the constructor,
		/// or generated internally using the salt and the password string.
		/// </summary>
		public string Hash { get; private set; }

		/// <summary>
		/// The hash's version; v1 = MD5, v2 = SHA-256.
		/// </summary>
		public int HashVersion { get; private set; }

		/// <summary>
		/// Checks the given password string to see if it matches the one
		/// used to create this hashed password.
		/// </summary>
		public bool CheckPassword(string passwordToCheck)
		{
			string hashToCheck = CreateHash(passwordToCheck, this.Salt, this.HashVersion);
			return (hashToCheck == this.Hash);
		}

		/// <summary>
		/// Creates a new randomized salt value.
		/// </summary>
		private static string CreateSalt()
		{
			string guidString = Guid.NewGuid().ToString();
			return guidString.Substring(guidString.LastIndexOf('-') + 1);
		}

		/// <summary>
		/// Creates a new hash, given a password string, salt value, and hash version to use.
		/// </summary>
		private static string CreateHash(string password, string salt, int hashVersion)
		{
			// the global secret used in password hashing;
			// you can't ever change this, or all users will be unable to log in
			string globalSecret = "terceS-hap00S,1ABo1G";
			string valueToHash = salt + password + salt + globalSecret;

			if (hashVersion == 1)
			{
				return new MD5(valueToHash).HashString;
			}
			else if (hashVersion == 2)
			{
				// the key used in passphase hashing;
				// you can't ever change this, or all users with v2 hashes will be unable to log in
				string globalHashKey = "xN3Jar4Uvw9HPbGBAVesRq2Lz2KxyMPegf4bNS9nSsCDgLbh";

				var encoding = new System.Text.UTF8Encoding();
				byte[] globalHashKeyBytes = encoding.GetBytes(globalHashKey);
				byte[] valueToHashBytes = encoding.GetBytes(valueToHash);

				var sha = new System.Security.Cryptography.HMACSHA256(globalHashKeyBytes);
				byte[] hash = sha.ComputeHash(valueToHashBytes);
				return Convert.ToBase64String(hash);
			}
			else
			{
				throw new ApplicationException("Invalid hash version");
			}
		}
	}
}