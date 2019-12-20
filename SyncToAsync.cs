using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SyncToAsync
{
    public class SyncToAsync
    {
        private readonly ILogger<SyncToAsync> logger;

        public SyncToAsync(ILogger<SyncToAsync> logger)
        {
            this.logger = logger;
        }

        public void Method()
        {
            var task = Task.Run(async () =>
                {
                    try
                    {
                        await MethodAsync().ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e, $"Error in Async Method.");
                        throw;
                    }



                    return true;
                }
            ).GetAwaiter().GetResult();
        }

        public async Task MethodAsync()
        {
            await Task.CompletedTask;
        }
    }
}
