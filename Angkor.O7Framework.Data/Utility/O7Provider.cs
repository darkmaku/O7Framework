// Created by Felix A. Bueno in 29/09/2016

using System.Configuration;
using Angkor.O7Framework.Data.Exception;

namespace Angkor.O7Framework.Data.Utility
{
    public class O7Provider
    {
        public static string DataBaseConection (string user, string password)
        {
             var connection = ConfigurationManager.GetSection ("O7Connection") as O7Connection;
            if (connection == null) throw O7DataException.MakeConnectionException;
            return $"Data Source={connection.Server}; User Id={user}; Password={password};";
        }
    }
}