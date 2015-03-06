using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;

namespace Microsoft.Online.PasswordSynchronization
{
	internal class Rc4Key : CriticalFinalizerObject, IDisposable
	{
		private unsafe RC4_KEYSTRUCT* rc4Key;

		public RC4_KEYSTRUCT* Key
		{
			get
			{
				return this.rc4Key;
			}
		}

		private unsafe void !Rc4Key()
		{
			RC4_KEYSTRUCT* rC4KEYSTRUCTPointer = this.rc4Key;
			if (rC4KEYSTRUCTPointer != null)
			{
				<Module>.delete(rC4KEYSTRUCTPointer);
				this.rc4Key = (RC4_KEYSTRUCT*)((long)0);
			}
		}

		public Rc4Key(byte[] keyBytes)
		{
			if (keyBytes == null)
			{
				throw new ArgumentNullException("keyBytes");
			}
			int length = keyBytes.Length;
			if (length == 0 || length > 255)
			{
				throw new ArgumentOutOfRangeException("keyBytes", (object)length, "The key length must be less than 256");
			}
			this.rc4Key = (RC4_KEYSTRUCT*)<Module>.@new((ulong)264);
			/* modopt(System.Runtime.CompilerServices.IsExplicitlyDereferenced) */ byte* byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu0029 = &keyBytes[0];
			<Module>.rc4_key(this.rc4Key, (uint)keyBytes.Length, byteu0026u0020modoptu0028Systemu002eRuntimeu002eCompilerServicesu002eIsExplicitlyDereferencedu0029);
		}

		private void ~Rc4Key()
		{
			this.!Rc4Key();
			GC.SuppressFinalize(this);
		}

		[HandleProcessCorruptedStateExceptions]
		protected virtual void Dispose(bool flag)
		{
			if (!flag)
			{
				try
				{
					this.!Rc4Key();
				}
				finally
				{
					base.Finalize();
				}
			}
			else
			{
				this.~Rc4Key();
			}
		}

		public sealed override void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected override void Finalize()
		{
			this.Dispose(false);
		}
	}
}