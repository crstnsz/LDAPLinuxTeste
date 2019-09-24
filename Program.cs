using System;
using Novell.Directory.Ldap;

namespace OpenLdapTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "admin";
            string domainName = "localhost";
            string password = "admin";

            string userDn = $"cn=admin,dc=example,dc=org";
            try
            {
                using (var connection = new LdapConnection {SecureSocketLayer = false})
                {
                    connection.Connect("localhost", LdapConnection.DEFAULT_PORT);
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
