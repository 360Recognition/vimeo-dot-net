﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VimeoDotNet.Authorization;
using VimeoDotNet.Constants;
using VimeoDotNet.Enums;
using VimeoDotNet.Exceptions;
using VimeoDotNet.Models;
using VimeoDotNet.Net;

namespace VimeoDotNet
{
    public partial class VimeoClient
    {
        #region Authorization

        public AccessTokenResponse GetAccessToken(string authorizationCode, string redirectUrl)
        {
            return OAuth2Client.GetAccessTokenAsync(authorizationCode, redirectUrl).Result;
        }

        #endregion

        #region Account

        public User GetAccountInformation()
        {
            try
            {
                return GetAccountInformationAsync().Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        #endregion

        #region Videos

        public Paginated<Video> GetAccountVideos()
        {
            try
            {
                return GetAccountVideosAsync().Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        public Video GetAccountVideo(long clipId)
        {
            try
            {
                return GetAccountVideoAsync(clipId).Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        public Paginated<Video> GetUserVideos(long userId)
        {
            try
            {
                return GetUserVideosAsync(userId).Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        public Video GetUserVideo(long userId, long clipId)
        {
            try
            {
                return GetUserVideoAsync(userId, clipId).Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        #endregion

        #region Upload

        public UploadTicket GetUploadTicket()
        {
            try
            {
                return GetUploadTicketAsync().Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        public IUploadRequest StartUploadFile(IBinaryContent fileContent, int chunkSize = DEFAULT_UPLOAD_CHUNK_SIZE)
        {
            try
            {
                return StartUploadFileAsync(fileContent, chunkSize).Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        public IUploadRequest UploadEntireFile(IBinaryContent fileContent, int chunkSize = DEFAULT_UPLOAD_CHUNK_SIZE)
        {
            try
            {
                return UploadEntireFileAsync(fileContent, chunkSize).Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        public VerifyUploadResponse ContinueUploadFile(IUploadRequest uploadRequest)
        {
            try
            {
                return ContinueUploadFileAsync(uploadRequest).Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }
        
        public VerifyUploadResponse VerifyUploadFile(IUploadRequest uploadRequest) {
            try
            {
                return VerifyUploadFileAsync(uploadRequest).Result;
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                return null;
            }
        }

        public void CompleteFileUpload(IUploadRequest uploadRequest) {
            try
            {
                CompleteFileUploadAsync(uploadRequest).RunSynchronously();
            }
            catch (AggregateException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }
        }

        #endregion
    }
}
