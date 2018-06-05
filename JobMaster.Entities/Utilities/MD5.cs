
using System.Security.Cryptography;
using System.Text;

namespace JobMaster
{
    /// <summary>
	/// An MD5 hash.
	/// This is just a small convenience wrapper around system-provided functionality.
	/// </summary>
	public class MD5
    {
        /// <summary>
        /// Initializes a new instance, computing the hash for the passed bytes.
        /// </summary>
        /// <param name="bytes">The data to compute the hash for.</param>
        public MD5(byte[] bytes)
        {
            this.Hash = this.ComputeHash(bytes);
        }

        /// <summary>
        /// Initializes a new instance, computing the hash for the passed string.
        /// </summary>
        /// <param name="str">The string to compute the hash for.</param>
        public MD5(string str)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(str);
            this.Hash = this.ComputeHash(bytes);
        }

        /// <summary>
        /// The hash value, as a raw byte array.
        /// </summary>
        public byte[] Hash { get; private set; }

        /// <summary>
        /// The hash value, expressed as a 32-character lowercase hex string.
        /// </summary>
        public string HashString
        {
            get
            {
                if (string.IsNullOrEmpty(this._hashString))
                    this._hashString = this.StringifyHash(this.Hash);
                return this._hashString;
            }
        }

        /// <summary>
        /// Creates an MD5 hash of the given byte array, returning the result as a byte array.
        /// </summary>
        private byte[] ComputeHash(byte[] bytes)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            return md5.ComputeHash(bytes);
        }

        /// <summary>
        /// Converts the bytes of an MD5 hash to a 32-character lowercase hex string,
        /// which is the form in which MD5 hashes are usually stored and presented.
        /// </summary>
        private string StringifyHash(byte[] hashBytes)
        {
            StringBuilder sb = new StringBuilder(32);
            for (int byteNum = 0; byteNum < hashBytes.Length; ++byteNum)
                sb.Append(hashBytes[byteNum].ToString("x2"));

            return sb.ToString();
        }

        /// <summary>
        /// Private backing field for the HashString property.
        /// </summary>
        private string _hashString;
    }
}
