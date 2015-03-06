# Microsoft.Online.PasswordSynchronization
Fully managed implementation of Microsoft.Online.PasswordSynchronization.dll (because that would allow password sync on Server 2008)


## TODO:
 The most important missing element is decoding the original function OrgIdHashGenerator and implementating it using the opensource PBKDF2 included.
 
##References

* The function that limits everything, it exists only on 2008 R2 and after. https://msdn.microsoft.com/en-us/library/windows/desktop/dd433795(v=vs.85)
* Description of the encoded string from OrgIdHashGenerator: https://www.cogmotive.com/blog/office-365-tips/how-secure-is-dirsync-with-password-synchronisation
* PBKDF2 Implementation: https://code.google.com/p/csharptest-net/source/browse/src/?name=#src%2FLibrary%2FCrypto
* Help file for the PBKDF2: http://help.csharptest.net/CSharpTest.Net.Library~CSharpTest.Net.Crypto.PBKDF2.html
* MD4 Implementation from the Mono Project: https://github.com/mono/mono/tree/master/mcs/class/Mono.Security/Mono.Security.Cryptography
