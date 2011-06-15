require 'Albacore'
task :default=> [:build ,:test]
@build_output='build_output'
msbuild :build do |msb|
	Dir.mkdir(@build_output) unless File.exists?(@build_output)
	msb.solution="src/Goo.sln"
	msb.properties :configuration=>:Debug
	msb.targets :Clean,:Build
	msb.loggermodule = "FileLogger,Microsoft.Build.Engine;logfile=#{@build_output}/MyLog.log"
end

nunit :test do |nunit|
	nunit.command="tools/nunit/tools/nunit-console.exe"
	nunit.assemblies="src/tests/bin/debug/Tests.dll"
	nunit.options "/xml=#{@build_output}/MyProject.Tests-results.xml"
end