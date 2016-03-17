# vs2015-node-stubs
Simple do-nothing stub executables that mimic `node.exe`, `gulp.exe` and
`npm.exe`.

I was having problems with Visual Studio 2015 spinning up a raft of
multiple instances of node/npm/gulp and bringing my system to its knees.

See [my answer](http://stackoverflow.com/a/35351872/467473) to this Stack Overflow question, ["How can I disable Task Runner Explorer in Visual Studio?"](http://stackoverflow.com/q/31036318/467473) for what I used these for.

The page [http://ryanhayes.net/synchronize-node-js-install-version-with-visual-studio-2015/](http://ryanhayes.net/synchronize-node-js-install-version-with-visual-studio-2015/)
will show you how to configure Visual Studio 2015 to put these at
the front of the search path used by Visual Studio to locate executables.

To use this, you need to

* Build this solution.

* Copy the contents of `bin\Debug` or `bin\Release`
to a directory of your choosing. In my case that was
`C:\usr\local\dummy-node-tools\`. Your mileage may vary.

* Modify the Visual Studio 2015 search path as described above so
that it will locate your stub executables in preference to the actual
node/npm/gulp executables.

* Restart Visual Studio 2015 and do your thing for a bit.

* Shut down Visual Studio 2015: the stub executables should have
created a `logs` subdirectory underneath the directory to which
you copied the stub executables.

Navigate to that `logs` directory and take a look at what Visual
Studio 2015 was up to with respect to node/npm/gulp.

## NOTE

Feel free to modify that location of the `logs` directory.

If you do so, please be aware that you'll need to make two changes:

* In the log4net config file (`config.log4net`), and
* In the mothod `ApplicationBase.Run()` where it actually creates
the log file.

Note also that log4net will fail silently if its target directory
doesn't exist or the process running log4net lacks write permissions
on the target directory.

