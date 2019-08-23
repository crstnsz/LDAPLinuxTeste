using System;
using Novell.Directory.Ldap;

namespace OpenLdapTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "****";
            string domainName = "****";
            string password = "****";

            string userDn = $"{username}@{domainName}";
            try
            {
                using (var connection = new LdapConnection {SecureSocketLayer = false})
                {
                    connection.Connect(domainName, LdapConnection.DEFAULT_PORT);
                    connection.Bind(userDn, password);
                    if (connection.Bound)
                        Console.WriteLine("Sucesso");
                }
            }
            catch (LdapException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
