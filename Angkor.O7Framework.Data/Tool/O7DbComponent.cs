// Created by Felix A. Bueno in 29/09/2016

using System.Configuration;
using System.Diagnostics.Contracts;
using Angkor.O7Framework.Data.Model;

namespace Angkor.O7Framework.Data.Tool
{
    public class O7DbComponent
    {
        public static string BuildDbConection(string user, string password)
        {
            Contract.Requires(ConfigurationManager.GetSection("O7Connection") is O7DbConnection);
            var connection = (O7DbConnection)ConfigurationManager.GetSection("O7Connection");
            return $"Data Source={connection.Server}; User Id={user}; Password={password};";
        }
    }
}