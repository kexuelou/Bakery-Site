# Bakery-Site
ASP.NET Bakery Site from WebMatrix Gallery. The purpose is to demo diagnostics feature in Azure Websites.

### Setup DB
[Create a New Database by Importing BACPAC File](http://msdn.microsoft.com/en-us/library/azure/hh335292.aspx).

The BACPAC file is under site/app_data folder
### Web.config
Update the Web.config with the new SQL connection string.

###Slowness
click the "Carrot Cake"

###spike CPU
click the "Lemon Tart"

###Memory Leak
1. click the "Lemon Tart"
2. Each request will leak small piece of memory, strerss the site can create memory leak as well.

###Exception
click the "Pear Tart"

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)
