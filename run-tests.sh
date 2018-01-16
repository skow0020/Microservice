#!/bin/bash
set -eu -o pipefail

cd code
dotnet restore
cd ./test/Services.Tests/
dotnet xunit -xml ./test-results.xml