using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Imagekit;
using RestSharp;

/// <summary>
/// Summary description for imgKit
/// </summary>
public class imgKit
{
    ServerImagekit sImgKit;
    public string IKPubKey = "public_IoIL/XQEbLx5+mLaWT/svG/sCMU=";
    private string IKPrivateKey = "private_uzGlh7rnTs8HePeNVkrjqMmCrtw=";
    public string endPoint = "https://ik.imagekit.io/sniggle/";
    public string rootpath = "https://ik.imagekit.io/sniggle/";
    public string Authorization_Basic;
    public imgKit()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string getImgKitFullPath(string myValue)
    {
        myValue = rootpath + myValue;
        sImgKit = new ServerImagekit(IKPubKey, IKPrivateKey, endPoint, "path");
        Transformation transformation = new Transformation().Width(1349).Height(354);
        string imageURL = sImgKit.Url(transformation)
    .Src(myValue)
    .Generate();
        return imageURL;
    }

    public string getImgKitFullPath(string myValue, int width, int height)
    {
        myValue = rootpath + myValue;
        sImgKit = new ServerImagekit(IKPubKey, IKPrivateKey, endPoint, "path");
        Transformation transformation = new Transformation().Width(width).Height(height);
        string imageURL = sImgKit.Url(transformation)
    .Src(myValue)
    .Generate();
        return imageURL;
    }

    public string getImgKitwithouDimension(string myValue)
    {
        myValue = rootpath + myValue;
        sImgKit = new ServerImagekit(IKPubKey, IKPrivateKey, endPoint, "path");
        Transformation transformation = new Transformation();
        string imageURL = sImgKit.Url(transformation)
    .Src(myValue)
    .Generate();
        return imageURL;
    }

    public string getImgKitBanner2(string myValue)
    {
        sImgKit = new ServerImagekit(IKPubKey, IKPrivateKey, endPoint, "path");
        Transformation transformation = new Transformation().Width(569).Height(296);
        string imageURL = sImgKit.Url(transformation)
    .Src(myValue)
    .Generate();
        return imageURL;
    }
    public void uploadImgKit(string fName, string folderName, string imgFullPath)
    {
        sImgKit = new ServerImagekit(IKPubKey, IKPrivateKey, "https://ik.imagekit.io/sniggle/", "path");
        ImagekitResponse imgRes = sImgKit.FileName(fName).Folder("/img/" + folderName).UseUniqueFileName(false).Upload(imgFullPath);
    }

    public string moveImgKit(string sourceFilePath, string destinationPath)
    { 
    var client = new RestClient("https://api.imagekit.io/v1/files/move");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Authorization", "Basic cHJpdmF0ZV92bEdMZ1dGM0VkMzdSQU1pdGVUYjZmZTgzck09Og==");
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Cookie", "_csrf=FyytRUsDXZGOlByMbIP0bOfZ");
        request.AddParameter("application/json", "{\n    \"sourceFilePath\": \"" + sourceFilePath + "\",\n    \"destinationPath\": \"/" + destinationPath + "\"\n}", ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        return response.Content.ToString();
        //Console.WriteLine(response.Content);
    }
    public string imgKitMove(string sourceFilePath, string destinationPath)
    {
        //Image moved successfully then response get null
        Authorization_Basic = Base64Encode(IKPrivateKey + ":");
        var client = new RestClient("https://api.imagekit.io/v1/files/move");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Authorization", "Basic " + Authorization_Basic);
        request.AddHeader("Content-Type", "application/json");
        request.AddParameter("application/json", "{\n    \"sourceFilePath\": \"" + sourceFilePath + "\",\n    \"destinationPath\": \"/" + destinationPath + "\"\n}", ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        return response.Content.ToString();
    }
    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
}