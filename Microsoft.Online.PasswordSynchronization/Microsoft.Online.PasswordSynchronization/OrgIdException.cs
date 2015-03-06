using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Microsoft.Online.PasswordSynchronization
{
	[Serializable]
	public class OrgIdException : Exception
	{
		private const string ReturnCodeFieldName = "returnCode";

		private int returnCode;

		public int ReturnCode
		{
			get
			{
				return this.returnCode;
			}
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
		protected OrgIdException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			this.returnCode = info.GetInt32("returnCode");
		}

		public OrgIdException(string message, int returnCode, Exception inner) : base(message, inner)
		{
			this.returnCode = returnCode;
		}

		public OrgIdException(string message, int returnCode) : base(message)
		{
			this.returnCode = returnCode;
		}

		public OrgIdException(string message, Exception inner) : base(message, inner)
		{
		}

		public OrgIdException(string message) : base(message)
		{
		}

		public OrgIdException()
		{
		}

		[SecurityPermission(SecurityAction.LinkDemand, Flags=SecurityPermissionFlag.SerializationFormatter)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("returnCode", this.returnCode);
		}
	}
}