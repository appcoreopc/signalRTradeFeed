using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

//var connection3 = new signalR.HubConnectionBuilder().withUrl("wss://localhost:44320/streamingHub", {
//    skipNegotiation: true,
//    transport: signalR.HttpTransportType.WebSockets
//}).build();

//connection3.start()
//Remember to have this part of the javascript invocation. 
//connection3.stream("Counter", 10, 500)
//    .subscribe({
//    next: (item) =>
//    {
//        var li = document.createElement("li");
//        li.textContent = item;
//        document.getElementById("messagesList").appendChild(li);
//    },
//        complete: () =>
//        {
//            var li = document.createElement("li");
//            li.textContent = "Stream completed";
//            document.getElementById("messagesList").appendChild(li);
//        },
//        error: (err) =>
//        {
//            var li = document.createElement("li");
//            li.textContent = err;
//            document.getElementById("messagesList").appendChild(li);
//        },
//});

namespace webApiTrader.Trades
{
    public class StreamingHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("receivemessage", user, message);
        }

        public ChannelReader<int> Counter(int count, int delay, CancellationToken cancellationToken)
        {
            var channel = Channel.CreateUnbounded<int>();

            // We don't want to await WriteItemsAsync, otherwise we'd end up waiting 
            // for all the items to be written before returning the channel back to
            // the client.
            _ = WriteItemsAsync(channel.Writer, count, delay, cancellationToken);

            return channel.Reader;
        }

        private async Task WriteItemsAsync(ChannelWriter<int> writer, int count, int delay, CancellationToken cancellationToken)
        {
            Exception localException = null;
            try
            {
                for (var i = 0; i < count; i++)
                {
                    await writer.WriteAsync(i, cancellationToken);
                    // Use the cancellationToken in other APIs that accept cancellation
                    // tokens so the cancellation can flow down to them.
                    await Task.Delay(delay, cancellationToken);
                }
            }
            catch (Exception ex)
            {
                localException = ex;
            }
            finally
            {
                writer.Complete(localException);
            }
        }

        // Streaming data 
        public async IAsyncEnumerable<int> CounterValue(int count, int delay, [EnumeratorCancellation]CancellationToken cancellationToken)
        {
            for (var i = 0; i < count; i++)
            {
                // Check the cancellation token regularly so that the server will stop
                // producing items if the client disconnects.
                cancellationToken.ThrowIfCancellationRequested();

                yield return i;

                // Use the cancellationToken in other APIs that accept cancellation
                // tokens so the cancellation can flow down to them.
                await Task.Delay(delay, cancellationToken);
            }
        }

        //// Client to server streaming
        //public async Task UploadStream(ChannelReader<string> stream)
        //{           
        //    while (await stream.WaitToReadAsync())
        //    {
        //        while (stream.TryRead(out var item))
        //        {
        //            // do something with the stream item
        //            Console.WriteLine(item);
        //        }
        //    }
        //}
    }


}
