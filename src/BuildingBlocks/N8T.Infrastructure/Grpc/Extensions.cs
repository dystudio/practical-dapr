using System;
using System.Text.Json;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.DependencyInjection;

namespace N8T.Infrastructure.Grpc
{
    public static class Extensions
    {
        public static Any ConvertToAnyAsync<T>(this T data, JsonSerializerOptions options = null)
        {
            options ??= new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var any = new Any();

            if (data == null)
                return any;
            var bytes = JsonSerializer.SerializeToUtf8Bytes(data, options);
            any.Value = ByteString.CopyFrom(bytes);

            return any;
        }

        public static IServiceCollection AddCustomGrpc(this IServiceCollection services,
            Action<IServiceCollection> doMoreActions = null)
        {
            services.AddGrpc(options =>
            {
                options.Interceptors.Add<RequestLoggerInterceptor>();
                options.Interceptors.Add<ExceptionHandleInterceptor>();
                options.EnableDetailedErrors = true;
            });

            doMoreActions?.Invoke(services);

            return services;
        }

        public static IServiceCollection AddCustomGrpcClient(this IServiceCollection services,
            Action<IServiceCollection> doMoreActions = null)
        {
            //AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            services.AddSingleton<ClientLoggerInterceptor>();

            doMoreActions?.Invoke(services);

            return services;
        }
    }
}
