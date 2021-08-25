# mr-shtrahman


## Reset DB instructions
To remove the Db and create a new one from scratch

 1. *Remove old DB* - Renove the Db folder it should located at `C:\Users\{user}\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb`
 2. *Remove everything under the Migrations folder*
 3. *On Nuget package manger console* :
	 * `Add-Migration <migration-name>`
	 * `Update-Database`
 4. *Run the project*
