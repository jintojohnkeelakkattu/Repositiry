// Copyright (c) 2018 JobMaster, Inc. All rights reserved.

using System;
using System.Runtime.Serialization;

namespace JobMaster
{
	/// <summary>
	/// An exception which occurred during normal operation, and which is meant to communicate an expected
	/// logical 'error' condition from one part of code to another (potentially code outside our control).
	/// 
	/// This class should not be used to represent internal coding errors or unexpected conditions,
	/// although the error represented might require the dev team's attention, depending on the circumstances.
	/// 
	/// This is the base class for all standard exceptions; use a specific subclass to actually raise one.
	/// </summary>
	public abstract class BaseException : ApplicationException
	{
		/// <summary>
		/// Creates a new instance with the given error message.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		public BaseException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Creates a new instance with the given error message,
		/// and a reference to the inner exception that is the cause of this exception.
		/// </summary>
		/// <param name="message">A message that describes the error.</param>
		/// <param name="innerException">
		/// The exception that is the cause of the current exception. If innerException is not a null reference,
		/// the current exception is raised in a catch block that handles the inner exception.
		/// </param>
		public BaseException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Creates a new instance with serialized data.
		/// </summary>
		/// <param name="info">The object that holds the serialized object data.</param>
		/// <param name="context">The contextual information about the source or destination.</param>
		protected BaseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}