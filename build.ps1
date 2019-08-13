if (test-path .\ouput)
{
    rmdir .\ouput -recursive
}

dotnet build --configuration release --output output
dotnet vstest .\output\GildedRose.Tests.dll