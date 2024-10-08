﻿namespace Ecommerce.Application.Common.BaseResponse
{
    public class ResponseHandler
    {
        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }
        public Response<T> Deleted<T>(string message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message
            };
        }

        public Response<T> Success<T>(T entity, object Meta = null, string message = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message == null ? "Opreation Done Successfully" : message,
                Meta = Meta
            };
        }

        public Response<T> Success<T>(object Meta = null, string message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message == null ? "Opreation Done Successfully" : message,
                Meta = Meta
            };
        }

        public Response<T> Unauthorized<T>(string message)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = string.IsNullOrEmpty(message) ? "UnAuthorized" : message
            };
        }

        public Response<T> BadRequest<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = Meta
            };
        }

        public Response<T> Created<T>(T Id, string message, object Meta = null)
        {
            return new Response<T>()
            {
                Data = Id,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = message == null ? "Created" : message,
                Meta = Meta
            };
        }
    }

}
