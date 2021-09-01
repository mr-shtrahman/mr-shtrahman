# mr-shtrahman


## Reset DB instructions
To remove the Db and create a new one from scratch

 1.close the sqlservr.exe prosses (open task manager in the Details tab)
 2.  *Remove old DB* - 	Remove the Db folder it should located at `C:\Users\{user}\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb`
 	 		Remove the Db folder it should located at `C:\Users\{user}\Context-ad3a71b0-7390-4ff8-8899-d20006cfd0e1.mdf`and
 			`C:\Users\{user}\Context-ad3a71b0-7390-4ff8-8899-d20006cfd0e1_log.ldf`
 2. *Remove everything under the Migrations folder*
 3. *On Nuget package manger console* :
	 * `Add-Migration <migration-name>`
	 * `Update-Database`
 4. *Run the project*
