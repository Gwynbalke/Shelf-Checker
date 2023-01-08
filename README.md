# Shelf-Checker
Projekt zaliczeniowy - Programowanie zaawansowane



Baza danych, z którą łączy się aplikacja działa lokalnie za pośrednictwem Microsoft SQL Server, w celu połączenia się z bazą należy zaimportować gotowy plik "baza.bacpac" do programu SQL Server, a także podmienić „connectionString” w pliku "Web.config"na lokalnie utworzony server:

	<connectionStrings>
		<add name="mycon" connectionString="server=DESKTOP-E7TFH26\SQLEXPRESS;database=baza;integrated security=true;" />
	</connectionStrings> 
  
 Link do lokalnie zahostowanej strony -  https://localhost:44379/login.aspx
