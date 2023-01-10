# Shelf-Checker
Projekt zaliczeniowy - Programowanie zaawansowane



Baza danych, z którą łączy się aplikacja działa lokalnie za pośrednictwem Microsoft SQL Server, w celu połączenia się z bazą należy zaimportować gotowy plik "baza.bacpac" do programu SQL Server, a także podmienić „connectionString” w pliku "Web.config"na lokalnie utworzony server:

	<connectionStrings>
		<add name="mycon" connectionString="server=DESKTOP-E7TFH26\SQLEXPRESS;database=baza;integrated security=true;" />
	</connectionStrings> 
  
 


Zalogować się można za pośrednictwem poniższego usera:

login - user

hasło - user123



----------------------------------------------------------------------

POPRAWIONA WERSJA PROJEKTU ŁĄCZY SIĘ Z BAZĄ DANYCH W CHMURZE (AZURE).
NIE MA W NIEJ POTRZEBY ZMIANY PLIKU ANI POBRANIA SQL MICROSOFT.

Zahostowana poprawiona aplikacja jest dostepna pod linkiem: https://projekt20230110201902.azurewebsites.net/

----------------------------------------------------------------------
