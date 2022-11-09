using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using System;
using System.Data;

namespace IziTradeOff.Persistence.Connection
{
    //add-migration InitialMig
    //update-database

    public class ConexionMysql : IDesignTimeDbContextFactory<IConexion>
    {
        /// <summary>
        /// Implementacion de patron contexto en tiempo de diseño
        /// </summary>
        /// <param name="args">Argumentos del diseño</param>
        /// <returns>Instancia de la clase IConexion con mysql</returns>
        /// Johnny Arcia
        public IConexion CreateDbContext(string[] args)
        {
            var connectionString = SingletonConexiones.ConnectionString;
            //Activar esta opcion solo para hacer migracion, ya que si se deja activa no conectara con la bd al ejecutar
            //connectionString = "server=localhost;port=3306;database=IziTradeOffDB;user=miguser;password=12345Abc@~;old guids=true;default command timeout=800;CharSet=utf8;pooling=false;AllowUserVariables=True;";
            //---------------------------------------------
            var optionsBuilder = new DbContextOptionsBuilder<IConexion>();
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            optionsBuilder.UseMySql<IConexion>(connectionString, mysqlOptions =>
            {
                mysqlOptions.ServerVersion(serverVersion);
            });

            return new IConexion(optionsBuilder.Options);
        }

        /// <summary>
        /// Obtenemos las variables de entorno
        /// </summary>
        /// <param name="name">Nombre variable</param>
        /// <param name="errorMessage">Mensaje si ocurre un error</param>
        /// <returns>Retorna el valor de la variable</returns>
        /// <exception cref="Exception">Si resulta una excepcion entonces se guarda en la variable errorMessage</exception>
        /// Johnny Arcia
        private string GetEnvironmentVariable(string name, string errorMessage)
        {
            Console.WriteLine(Environment.GetEnvironmentVariable(name));

            var connectionStringName = Environment.GetEnvironmentVariable(name);
            if (string.IsNullOrWhiteSpace(connectionStringName))
            {
                throw new Exception(errorMessage);
            }
            return connectionStringName;
        }
    }

}