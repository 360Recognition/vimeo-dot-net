﻿using System.Collections.Generic;
using System.Threading.Tasks;
using VimeoDotNet.Models;
using VimeoDotNet.Net;
using VimeoDotNet.Parameters;

namespace VimeoDotNet
{
    public interface IVimeoClient
    {
		// User Authentication
        AccessTokenResponse GetAccessToken(string authorizationCode, string redirectUrl);
        Task<AccessTokenResponse> GetAccessTokenAsync(string authorizationCode, string redirectUrl);
		string GetOauthUrl(string redirectUri, IEnumerable<string> scope, string state);

		// User Information
        User GetAccountInformation();
        Task<User> GetAccountInformationAsync();
        User GetUserInformation(long userId);
        Task<User> GetUserInformationAsync(long userId);

		// Retrieve Videos
		// ...by id
        Video GetVideo(long clipId);
        Task<Video> GetVideoAsync(long clipId);
		// ...for current account
        Paginated<Video> GetVideos();
        Task<Paginated<Video>> GetVideosAsync(int? page, int? perPage);
		// ...for another acount
        Video GetUserVideo(long userId, long clipId);
        Task<Video> GetUserVideoAsync(long userId, long clipId);
        Paginated<Video> GetUserVideos(long userId, string query = null);
        Task<Paginated<Video>> GetUserVideosAsync(long userId, string query = null);
		// ...for an album
        Paginated<Video> GetAlbumVideos(long albumId, int? page, int? perPage, string sort = null, string direction = null);
        Task<Paginated<Video>> GetAlbumVideosAsync(long albumId, int? page, int? perPage, string sort = null, string direction = null);
        Video GetAlbumVideo(long albumId, long clipId);
        Task<Video> GetAlbumVideoAsync(long albumId, long clipId);
        Paginated<Video> GetUserAlbumVideos(long userId, long albumId);
        Task<Paginated<Video>> GetUserAlbumVideosAsync(long userId, long albumId);
        Video GetUserAlbumVideo(long userId, long albumId, long clipId);
        Task<Video> GetUserAlbumVideoAsync(long userId, long albumId, long clipId);

		// Update Video Metadata
		void UpdateVideoMetadata(long clipId, VideoUpdateMetadata metaData);
		Task UpdateVideoMetadataAsync(long clipId, VideoUpdateMetadata metaData);

		// Uploading Files
		UploadTicket GetUploadTicket();
		Task<UploadTicket> GetUploadTicketAsync();
		IUploadRequest UploadEntireFile(IBinaryContent fileContent, int chunkSize = VimeoClient.DEFAULT_UPLOAD_CHUNK_SIZE);
		Task<IUploadRequest> UploadEntireFileAsync(IBinaryContent fileContent, int chunkSize = VimeoClient.DEFAULT_UPLOAD_CHUNK_SIZE);
		VerifyUploadResponse VerifyUploadFile(IUploadRequest uploadRequest);
		Task<VerifyUploadResponse> VerifyUploadFileAsync(IUploadRequest uploadRequest);
		IUploadRequest StartUploadFile(IBinaryContent fileContent, int chunkSize = VimeoClient.DEFAULT_UPLOAD_CHUNK_SIZE);
		Task<IUploadRequest> StartUploadFileAsync(IBinaryContent fileContent, int chunkSize = VimeoClient.DEFAULT_UPLOAD_CHUNK_SIZE);
		VerifyUploadResponse ContinueUploadFile(IUploadRequest uploadRequest);
		Task<VerifyUploadResponse> ContinueUploadFileAsync(IUploadRequest uploadRequest);
		void CompleteFileUpload(IUploadRequest uploadRequest);
		Task CompleteFileUploadAsync(IUploadRequest uploadRequest);

		// Albums
		Task<Paginated<Album>> GetAccountAlbumsAsync(GetAlbumsParameters parameters = null);
		Task<Paginated<Album>> GetUserAlbumsAsync(long userId, GetAlbumsParameters parameters = null);
		Paginated<Album> GetAccountAlbums(GetAlbumsParameters parameters = null);
		Paginated<Album> GetUserAlbums(long userId, GetAlbumsParameters parameters = null);

		// Deleting Videos
		void DeleteVideo(long clipId);
		Task DeleteVideoAsync(long clipId);
    }
}