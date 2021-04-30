for mysql:-
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Tools
Pomelo.EntityFrameworkCore.MySql

first time command execution - 
Scaffold-DbContext "Server=localhost;Port=3306;Database=userdb;User=root;Password=Mysql@12345" Pomelo.EntityFrameworkCore.MySql -OutputDir .\Models\DBModels

command execution to force changes
Scaffold-DbContext "Server=localhost;Port=3306;Database=userdb;User=root;Password=Mysql@12345" Pomelo.EntityFrameworkCore.MySql -OutputDir .\Models\DBModels -f