The file `npm.cmd` is a batch file "wrapper" around the actual
NPM executable (`npm.exe`) on Windows systems.

It appears that when Visual Studio 2015 spawns an NPM process,
it actually runs a command shell (`cmd.exe`) that invokes the
`npm.cmd` batch file, rather than directly invoking `npm.exe`.

Therefore, you'll need to customize the path in `npm.cmd` to
with the fully qualified path to **your** dummy instance of
`npm.exe`.

Note that in the Visual Studio project, `npm.cmd` is tagged as `content`
to be copied to the output (`bin`) directory, along with the compiled
executables.
