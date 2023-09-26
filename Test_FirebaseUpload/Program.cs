// See https://aka.ms/new-console-template for more information
using AppService;
using AppService.Implementation;

IFirebaseService firebaseService = new FirebaseService();
await firebaseService.UploadFile();
