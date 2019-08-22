using System;


namespace VirtualGit.Util
{
    public static class CommonHelper
    {
        public static string GetCurrentUser ( )
        {
            var loggedInUser = System.Threading.Thread.CurrentPrincipal!=null ? System.Threading.Thread.CurrentPrincipal.Identity.Name : string.Empty;

            try
            {          //Note: This will return value when site is running from IIS. Make sure site has the following settings - Widows Authentication is enabled & Anonymous Authentication is Disabled
                if (string.IsNullOrWhiteSpace ( loggedInUser ))
                {
                    //Note: This is required when site is running from Local IIS and in such case "CurrentPrinciple.Identity.Name" will be empty.
                    var windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent ();
                    loggedInUser=windowsIdentity!=null&&!string.IsNullOrEmpty ( windowsIdentity.Name )
                        ? windowsIdentity.Name
                        : string.Empty;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return loggedInUser;
        }
    }
}
