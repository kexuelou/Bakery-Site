# Bakery-Site
ASP.NET Bakery Site from WebMatrix Gallery. The purpose is to demo diagnostics feature in Azure Websites.

##Setup
### Setup DB
[Create a New Database by Importing BACPAC File](http://msdn.microsoft.com/en-us/library/azure/hh335292.aspx).

The BACPAC file is under site/app_data folder
### Web.config
Update the Web.config with the new SQL connection string.

##Scenarios
###Slowness
click the "Carrot Cake"

###spike CPU
Each request to "Lemon Tart" will do a small "calculation", stressing this this page will generate a high CPU scenario.

This command uses 10 threads to generate 1,000 requests totally.
tinyget -srv:"bestbakery.azurewebsites.net"
        -uri:"http://bestbakery.azurewebsites.net/order/2"
        -x:10 -l:100

###Memory Leak
Each request to this site will "leak" small part of managed memory. stressign this site, the memory usage will keep going up.

Each request to Cupcakes ("/order/3") leaks memory much faster. Stress this site if you want agressive leak.

This command uses 10 threads to generate 1,000 requests totally. The private bytes will exceed 500MB in a minute.

tinyget -srv:"bestbakery.azurewebsites.net"
        -uri:"http://bestbakery.azurewebsites.net/order/3"
        -x:10 -l:100


###Exception
click the "Pear Tart"

###Click the button below to deploy the site to Azure Websites
[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)
