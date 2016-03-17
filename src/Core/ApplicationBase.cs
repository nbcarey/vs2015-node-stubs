using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;

namespace Core
{
    public class ApplicationBase
    {
        private static readonly string exePath = Assembly.GetEntryAssembly().Location ;
        private static readonly string exeDir  = Path.GetDirectoryName( exePath ) ;
        private static readonly string exeName = Path.GetFileName( exePath );
        private static readonly ILog   log     = LogManager.GetLogger( exeName );

        public static void Run( string[] args )
        {
            DirectoryInfo root = new DirectoryInfo(exeDir) ;
            root.CreateSubdirectory( "logs" ) ;
            log.InfoFormat( "args: {0} " , FormatArgv( args ) ) ;
            return ;
        }

        private static string FormatArgv( string[] args )
        {
            if ( args == null ) throw new ArgumentNullException("args") ;
            if ( args.Length == 0 ) return "-none-" ;

            return string.Join( ", " , args.Select( s => Quotify( s ) ) );

        }

        private static object Quotify( string s )
        {
            const string QT = "\"" ;
            return QT + s.Replace( QT , QT+QT ) + QT ;
        }

    }
}
