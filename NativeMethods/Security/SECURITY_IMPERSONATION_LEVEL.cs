namespace Xcalibur.NativeMethods.Security
{
    /// <summary>
    /// Security impersonation level.
    /// </summary>
    public enum SECURITY_IMPERSONATION_LEVEL : int
    {
        SecurityAnonymous = 0,
        SecurityIdentification = 1,
        SecurityImpersonation = 2,
        SecurityDelegation = 3,
    }
}
