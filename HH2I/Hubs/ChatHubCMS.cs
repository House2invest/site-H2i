namespace House2Invest.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChatHubCMS : Hub
    {
        private static HashSet<string> CurrentConnections = new HashSet<string>();

        [CompilerGenerated, DebuggerHidden]
        private Task <>n__0()
        {
            return base.OnConnectedAsync();
        }

        [CompilerGenerated, DebuggerHidden]
        private Task <>n__1(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        public List<string> GetAllActiveConnections()
        {
            return Enumerable.ToList<string>((IEnumerable<string>) CurrentConnections);
        }

        [AsyncStateMachine((Type) typeof(<OnConnectedAsync>d__4))]
        public override Task OnConnectedAsync()
        {
            <OnConnectedAsync>d__4 d__;
            d__.<>4__this = this;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<OnConnectedAsync>d__4>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [AsyncStateMachine((Type) typeof(<OnDisconnectedAsync>d__5))]
        public override Task OnDisconnectedAsync(Exception exception)
        {
            <OnDisconnectedAsync>d__5 d__;
            d__.<>4__this = this;
            d__.exception = exception;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<OnDisconnectedAsync>d__5>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [AsyncStateMachine((Type) typeof(<SendMessage>d__1))]
        public Task SendMessage(string user, string message)
        {
            <SendMessage>d__1 d__;
            d__.<>4__this = this;
            d__.user = user;
            d__.message = message;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<SendMessage>d__1>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        public Task SendMessageToCaller(string message)
        {
            CancellationToken token = new CancellationToken();
            return ClientProxyExtensions.SendAsync(base.get_Clients().get_Caller(), "ReceiveMessage", message, token);
        }

        public Task SendMessageToGroups(string message)
        {
            List<string> list1 = new List<string>();
            list1.Add("SignalR Users");
            List<string> list = list1;
            CancellationToken token = new CancellationToken();
            return ClientProxyExtensions.SendAsync(base.get_Clients().Groups((IReadOnlyList<string>) list), "ReceiveMessage", message, token);
        }

        [CompilerGenerated]
        private struct <OnConnectedAsync>d__4 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public ChatHubCMS <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                ChatHubCMS bcms = this.<>4__this;
                try
                {
                    TaskAwaiter awaiter;
                    TaskAwaiter awaiter2;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                    }
                    else if (num == 1)
                    {
                        awaiter2 = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                        goto TR_0005;
                    }
                    else
                    {
                        string item = bcms.get_Context().get_ConnectionId();
                        ChatHubCMS.CurrentConnections.Add(item);
                        CancellationToken token = new CancellationToken();
                        awaiter = bcms.get_Groups().AddToGroupAsync(bcms.get_Context().get_ConnectionId(), "SignalR Users", token).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ChatHubCMS.<OnConnectedAsync>d__4>(ref awaiter, ref this);
                            return;
                        }
                    }
                    awaiter.GetResult();
                    awaiter2 = bcms.<>n__0().GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0005;
                    }
                    else
                    {
                        this.<>1__state = num = 1;
                        this.<>u__1 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ChatHubCMS.<OnConnectedAsync>d__4>(ref awaiter2, ref this);
                    }
                    return;
                TR_0005:
                    awaiter2.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <OnDisconnectedAsync>d__5 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public ChatHubCMS <>4__this;
            public Exception exception;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                ChatHubCMS bcms = this.<>4__this;
                try
                {
                    TaskAwaiter awaiter;
                    TaskAwaiter awaiter2;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                    }
                    else if (num == 1)
                    {
                        awaiter2 = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                        goto TR_0005;
                    }
                    else
                    {
                        string item = Enumerable.FirstOrDefault<string>((IEnumerable<string>) ChatHubCMS.CurrentConnections, new Func<string, bool>(bcms.<OnDisconnectedAsync>b__5_0));
                        if (item != null)
                        {
                            ChatHubCMS.CurrentConnections.Remove(item);
                        }
                        CancellationToken token = new CancellationToken();
                        awaiter = bcms.get_Groups().RemoveFromGroupAsync(bcms.get_Context().get_ConnectionId(), "SignalR Users", token).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ChatHubCMS.<OnDisconnectedAsync>d__5>(ref awaiter, ref this);
                            return;
                        }
                    }
                    awaiter.GetResult();
                    awaiter2 = bcms.<>n__1(this.exception).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0005;
                    }
                    else
                    {
                        this.<>1__state = num = 1;
                        this.<>u__1 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ChatHubCMS.<OnDisconnectedAsync>d__5>(ref awaiter2, ref this);
                    }
                    return;
                TR_0005:
                    awaiter2.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <SendMessage>d__1 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public ChatHubCMS <>4__this;
            public string user;
            public string message;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                ChatHubCMS bcms = this.<>4__this;
                try
                {
                    TaskAwaiter awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        CancellationToken token = new CancellationToken();
                        awaiter = ClientProxyExtensions.SendAsync(bcms.get_Clients().User(this.user), "ReceiveMessage", this.message, token).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, ChatHubCMS.<SendMessage>d__1>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    awaiter.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult();
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }
    }
}

