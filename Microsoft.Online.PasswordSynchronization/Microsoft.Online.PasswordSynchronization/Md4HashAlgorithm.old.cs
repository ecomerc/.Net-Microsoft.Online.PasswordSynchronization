using System;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Microsoft.Online.PasswordSynchronization
{
	public sealed class Md4HashAlgorithm : HashAlgorithm
	{
		private unsafe MD4_CTX* md4Context;

		private unsafe void !Md4HashAlgorithm()
		{
			MD4_CTX* mD4CTXPointer = this.md4Context;
			if (mD4CTXPointer != null)
			{
				<Module>.delete(mD4CTXPointer);
				this.md4Context = (MD4_CTX*)((long)0);
			}
		}

		public unsafe Md4HashAlgorithm()
		{
			try
			{
				this.md4Context = (MD4_CTX*)<Module>.@new((ulong)104);
				this.Initialize();
			}
		}

		[HandleProcessCorruptedStateExceptions]
		protected sealed override void Dispose(bool flag)
		{
			if (!flag)
			{
				try
				{
					this.!Md4HashAlgorithm();
				}
				finally
				{
					base.Dispose(false);
				}
			}
			else
			{
				base.Dispose(true);
			}
		}

		protected sealed override void Finalize()
		{
			this.Dispose(false);
		}

		protected sealed override void HashCore(byte[] inputBuffer, int start, int size)
		{
			if (size != 0)
			{
				/* modopt(System.Runtime.CompilerServices.IsExplicitlyDereferenced) */ byte* byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu0029 = &inputBuffer[start];
				<Module>.MD4Update(this.md4Context, byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu0029, (uint)size);
			}
		}

		protected sealed override byte[] HashFinal()
		{
			<Module>.MD4Final(this.md4Context);
			byte[] numArray = new byte[16];
			IntPtr intPtr = new IntPtr(this.md4Context + (long)88);
			Marshal.Copy(intPtr, numArray, 0, 16);
			return numArray;
		}

		public sealed override void Initialize()
		{
			<Module>.MD4Init(this.md4Context);
		}
	}
}