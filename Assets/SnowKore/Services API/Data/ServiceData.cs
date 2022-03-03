using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using SnowKore.Utils;

namespace SnowKore.Services
{
    public abstract class newServiceData
    {
        private Action<string> LastServiceResponse;

        protected virtual string BaseURL
        {
            get
            {
                return "https://tridyapp.herokuapp.com/";
            }
        }

        protected abstract Dictionary<string, object> Body { get; }
        protected abstract string ServiceURL { get; }
        protected abstract Dictionary<string, object> Params { get; }
        protected abstract Dictionary<string, string> Headers { get; }
        protected abstract ServiceType ServiceType { get; }

        private byte[] JsonBody
        {
            get { return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(Body)); }
        }

        private string RequestURL
        {
            get { return BaseURL + ServiceURL; }
        }

        protected virtual bool ShouldSimulateResponse
        {
            get
            {
                return false;
            }
        }


        public IEnumerator SendAsync(Action<string> ServiceResponse)
        {
            Debug.Log("Send request " + ServiceURL + " with body: \n" + JsonConvert.SerializeObject(Body));
            LastServiceResponse = ServiceResponse;
            UnityWebRequestAsyncOperation request = GetRequest().SendWebRequest();
            yield return request;
            ProcessResponse(request, ServiceResponse);
        }

        public void Send(Action<string> ServiceResponse)
        {
            Debug.Log("Send request " + ServiceURL + " with body: \n" + JsonConvert.SerializeObject(Body));
            LastServiceResponse = ServiceResponse;
            UnityWebRequestAsyncOperation request = GetRequest().SendWebRequest();
            while (!request.isDone) { }
            ProcessResponse(request, ServiceResponse);
        }

        private void ProcessResponse(UnityWebRequestAsyncOperation request, Action<string> ServiceResponse)
        {
            if (Debug.isDebugBuild && ShouldSimulateResponse)
                ProcessSimulatedResponse(ServiceResponse);
            else
                ProcessNormalResponse(request, ServiceResponse);
        }

        private void ProcessNormalResponse(UnityWebRequestAsyncOperation request, Action<string> ServiceResponse)
        {
            Debug.Log("Request: " + request.webRequest.url + ", Response Code: [" + request.webRequest.responseCode + "]" + " Response Text: \n" + request.webRequest.downloadHandler.text);

            if (HasFailed(request.webRequest))
            {
                bool hasConnection = HasConnection();

                if (!hasConnection)
                    Debug.LogError("No Internet!");
                else
                    ServiceResponse?.Invoke(request.webRequest.downloadHandler.text);

                Debug.Log("Service " + RequestURL + " Error:\n" + request.webRequest.downloadHandler.text + "\nHasInternetConnection? " + hasConnection);
            }
            else
            {
                ServiceResponse?.Invoke(request.webRequest.downloadHandler.text);
            }
        }

        private void ProcessSimulatedResponse(Action<string> ServiceResponse)
        {
            string response = ResponseSimulator.GetSimulatedResponse(ServiceURL);
            Debug.Log("Request: " + RequestURL + ", Response Code: [SIMULATED]" + " Response Text: \n" + response);
            bool hasConnection = HasConnection();

            if (!hasConnection)
                Debug.LogError("No Internet!");
            else
                ServiceResponse?.Invoke(response);
        }

        private UnityWebRequest GetRequest()
        {
            UnityWebRequest request = null;

            if (ServiceType == ServiceType.POST || ServiceType == ServiceType.PATCH || ServiceType == ServiceType.DELETE)
                request = GetRequestTypePost();

            if (ServiceType == ServiceType.GET)
                request = GetRequestTypeGet();

            foreach (KeyValuePair<string, string> header in Headers)
                request.SetRequestHeader(header.Key, header.Value);

            request.SetRequestHeader("Auth", "YekB8wrXxhrkANQqYkElikipsy3gsVN1gq02y2ibNFgRGKt9rxz8q6ZYbeupXjaf3wGMAY73bnLjZSNCdkF1A==");
            return request;
        }

        private UnityWebRequest GetRequestTypePost()
        {
            UnityWebRequest request = UnityWebRequest.Post(RequestURL, new List<IMultipartFormSection>(), JsonBody);
            request.uploadHandler = new UploadHandlerRaw(JsonBody);
            request.method = ServiceType.ToString();
            return request;
        }

        private UnityWebRequest GetRequestTypeGet()
        {
            string finalUrl = RequestURL + Params.ToURL();
            return UnityWebRequest.Get(finalUrl);
        }

        private bool HasFailed(UnityWebRequest request)
        {
            bool isNetworkError = request.isNetworkError;
            bool isHttpError = request.isHttpError;
            bool hasFailed = isNetworkError || isHttpError;

            return hasFailed;
        }

        private bool HasConnection()
        {
            WWW www = new WWW("http://google.com");
            while (!www.isDone) { }

            if (www.error != null)
                return false;
            else
                return true;
        }
    }
}
