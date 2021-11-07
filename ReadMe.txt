https://docs.microsoft.com/en-us/dotnet/architecture/cloud-native/service-to-service-communication

https://localhost:44312/api/auth?name=user&pwd=pass

---------------------------------------------------------------------------------------------------------------------------------------
https://localhost:44312/api/getUserDetails
	Authorization:Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwianRpIjoiM2FhNzIyNTktMGRkZC00MGE3LTllMDAtYzc2M2Y2OTlhM2M1IiwiaWF0IjoiMDgtMDgtMjAyMSAwNzoxMjo0MiIsIm5iZiI6MTYyODQwNjc2MiwiZXhwIjoxNjI4NDA3OTYyLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzEyIiwiYXVkIjoibG9jYWxIb3N0In0.F6kcuFZHUObWGL8JJUekpRN_CdzBXSEcK9jXAoshyjQ

---------------------------------------------------------------------------------------------------------------------------------------
https://localhost:44312/api/saveUserDetails
	Authorization:Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwianRpIjoiM2FhNzIyNTktMGRkZC00MGE3LTllMDAtYzc2M2Y2OTlhM2M1IiwiaWF0IjoiMDgtMDgtMjAyMSAwNzoxMjo0MiIsIm5iZiI6MTYyODQwNjc2MiwiZXhwIjoxNjI4NDA3OTYyLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzEyIiwiYXVkIjoibG9jYWxIb3N0In0.F6kcuFZHUObWGL8JJUekpRN_CdzBXSEcK9jXAoshyjQ
{
	"Code":"usercode",
	"Name":"username",
	"Address":"useraddress",
	"PhoneNumber":"userPhoneNumber"
}

---------------------------------------------------------------------------------------------------------------------------------------
https://localhost:44312/api/updateUserDetails
	Authorization:Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwianRpIjoiM2FhNzIyNTktMGRkZC00MGE3LTllMDAtYzc2M2Y2OTlhM2M1IiwiaWF0IjoiMDgtMDgtMjAyMSAwNzoxMjo0MiIsIm5iZiI6MTYyODQwNjc2MiwiZXhwIjoxNjI4NDA3OTYyLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzEyIiwiYXVkIjoibG9jYWxIb3N0In0.F6kcuFZHUObWGL8JJUekpRN_CdzBXSEcK9jXAoshyjQ
	Content-Type:application/json
{
	"userId":1,
	"Code":"usercode1",
	"Name":"username1",
	"Address":"useraddress1",
	"PhoneNumber":"userPhoneNumber1"
}
----------------------------------------------------------------------------------------------------------------------------------
https://localhost:44312/api/deleteUserDetails/1
	Authorization:Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c2VyIiwianRpIjoiM2FhNzIyNTktMGRkZC00MGE3LTllMDAtYzc2M2Y2OTlhM2M1IiwiaWF0IjoiMDgtMDgtMjAyMSAwNzoxMjo0MiIsIm5iZiI6MTYyODQwNjc2MiwiZXhwIjoxNjI4NDA3OTYyLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0OjQ0MzEyIiwiYXVkIjoibG9jYWxIb3N0In0.F6kcuFZHUObWGL8JJUekpRN_CdzBXSEcK9jXAoshyjQ
	Content-Type:application/json
----------------------------------------------------------------------------------------------------------------------------


