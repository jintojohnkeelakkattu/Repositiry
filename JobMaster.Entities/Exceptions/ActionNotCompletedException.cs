// Copyright (c) 2018 JobMaster, Inc. All rights reserved.

using System;

namespace JobMaster
{
	/// <summary>
	/// An exception which occurred because a user-requested action can't be completed for logical reasons;
	/// we're not down for maintenance, there were no input-validation problem, the record could be found, etc,
	/// but still, for some action-specific reason, the user's request can't/shouldn't be completed.
	/// This exception type has no default message, because it can potentially represent a wide array of disparate problems.
	/// </summary>
	public class ActionNotCompletedException : BaseException
	{
		/// <summary>
		/// Creates a new instance with the given error message.
		/// </summary>
		/// <param name="message">A message that describes why the action could not be completed.</param>
		public ActionNotCompletedException(string message)
			: base(message)
		{
		}
	}
}