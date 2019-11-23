namespace House2Invest.Hubs
{
    using House2Invest.Data;
    using House2Invest.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    [Authorize]
    public class NotificacoesHub : Hub
    {
        public static HashSet<string> ConexoesAtivas = new HashSet<string>();
        public static List<ClienteAtivo> ClientesAtivos = new List<ClienteAtivo>();
        private readonly ApplicationDbContext _context;

        public NotificacoesHub(ApplicationDbContext context)
        {
            this._context = context;
        }

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

        [AsyncStateMachine((Type) typeof(<EnviarMensagem>d__7))]
        public Task EnviarMensagem(string de, string para, string mens)
        {
            <EnviarMensagem>d__7 d__;
            d__.<>4__this = this;
            d__.de = de;
            d__.para = para;
            d__.mens = mens;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<EnviarMensagem>d__7>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [AsyncStateMachine((Type) typeof(<ForceLogoff>d__9))]
        public Task ForceLogoff(string para, string mens)
        {
            <ForceLogoff>d__9 d__;
            d__.<>4__this = this;
            d__.para = para;
            d__.mens = mens;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<ForceLogoff>d__9>(ref d__);
            return d__.<>t__builder.get_Task();
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

        [AsyncStateMachine((Type) typeof(<QuadroMens>d__8))]
        public Task QuadroMens(string para, string mens)
        {
            <QuadroMens>d__8 d__;
            d__.<>4__this = this;
            d__.para = para;
            d__.mens = mens;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<QuadroMens>d__8>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [AsyncStateMachine((Type) typeof(<Quem>d__6))]
        public Task Quem(string status, string idusu)
        {
            <Quem>d__6 d__;
            d__.<>4__this = this;
            d__.status = status;
            d__.idusu = idusu;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<Quem>d__6>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [AsyncStateMachine((Type) typeof(<Teclando>d__10))]
        public Task Teclando(string de, string para)
        {
            <Teclando>d__10 d__;
            d__.<>4__this = this;
            d__.de = de;
            d__.para = para;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<Teclando>d__10>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [AsyncStateMachine((Type) typeof(<Teste>d__11))]
        public Task Teste(string de, string para, string mens, string cnxde, string cnxpara)
        {
            <Teste>d__11 d__;
            d__.<>4__this = this;
            d__.de = de;
            d__.para = para;
            d__.mens = mens;
            d__.cnxde = cnxde;
            d__.cnxpara = cnxpara;
            d__.<>t__builder = AsyncTaskMethodBuilder.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<Teste>d__11>(ref d__);
            return d__.<>t__builder.get_Task();
        }

        [CompilerGenerated]
        private struct <EnviarMensagem>d__7 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public NotificacoesHub <>4__this;
            public string de;
            public string para;
            public string mens;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                NotificacoesHub hub = this.<>4__this;
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
                        awaiter = ClientProxyExtensions.SendAsync(hub.get_Clients().get_All(), "enviarmens", hub.get_Context().get_ConnectionId(), this.de, this.para, this.mens, token).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<EnviarMensagem>d__7>(ref awaiter, ref this);
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

        [CompilerGenerated]
        private struct <ForceLogoff>d__9 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public NotificacoesHub <>4__this;
            public string para;
            public string mens;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                NotificacoesHub hub = this.<>4__this;
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
                        awaiter = ClientProxyExtensions.SendAsync(hub.get_Clients().Client(this.para), "forcelogoff", hub.get_Context().get_ConnectionId(), this.para.Replace("@", "").Replace(".", ""), this.mens, token).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<ForceLogoff>d__9>(ref awaiter, ref this);
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

        [CompilerGenerated]
        private struct <OnConnectedAsync>d__4 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public NotificacoesHub <>4__this;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                NotificacoesHub hub = this.<>4__this;
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
                        NotificacoesHub.<>c__DisplayClass4_0 class_;
                        HubCallerContext _contextoConexao = hub.get_Context();
                        ParameterExpression expression = Expression.Parameter((Type) typeof(UsuarioApp), "x");
                        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
                        UsuarioApp app = Queryable.FirstOrDefault<UsuarioApp>(hub._context.get_Users(), Expression.Lambda<Func<UsuarioApp, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(IdentityUser<string>.get_UserName, IdentityUser<string>)), (Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Field((Expression) Expression.Constant(class_, (Type) typeof(NotificacoesHub.<>c__DisplayClass4_0)), fieldof(NotificacoesHub.<>c__DisplayClass4_0._contextoConexao)), (MethodInfo) methodof(HubCallerContext.get_User)), (MethodInfo) methodof(ClaimsPrincipal.get_Identity)), (MethodInfo) methodof(IIdentity.get_Name))), expressionArray1));
                        awaiter = hub.Quem("ENTROU", app.get_Id()).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<OnConnectedAsync>d__4>(ref awaiter, ref this);
                            return;
                        }
                    }
                    awaiter.GetResult();
                    awaiter2 = hub.<>n__0().GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0005;
                    }
                    else
                    {
                        this.<>1__state = num = 1;
                        this.<>u__1 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<OnConnectedAsync>d__4>(ref awaiter2, ref this);
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
            public NotificacoesHub <>4__this;
            public Exception exception;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                NotificacoesHub hub = this.<>4__this;
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
                        NotificacoesHub.<>c__DisplayClass5_0 class_;
                        HubCallerContext _contextoConexao = hub.get_Context();
                        ParameterExpression expression = Expression.Parameter((Type) typeof(UsuarioApp), "x");
                        ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
                        UsuarioApp app = Queryable.FirstOrDefault<UsuarioApp>(hub._context.get_Users(), Expression.Lambda<Func<UsuarioApp, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(IdentityUser<string>.get_UserName, IdentityUser<string>)), (Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Property((Expression) Expression.Field((Expression) Expression.Constant(class_, (Type) typeof(NotificacoesHub.<>c__DisplayClass5_0)), fieldof(NotificacoesHub.<>c__DisplayClass5_0._contextoConexao)), (MethodInfo) methodof(HubCallerContext.get_User)), (MethodInfo) methodof(ClaimsPrincipal.get_Identity)), (MethodInfo) methodof(IIdentity.get_Name))), expressionArray1));
                        awaiter = hub.Quem("SAIU", app.get_Id()).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<OnDisconnectedAsync>d__5>(ref awaiter, ref this);
                            return;
                        }
                    }
                    awaiter.GetResult();
                    awaiter2 = hub.<>n__1(this.exception).GetAwaiter();
                    if (awaiter2.IsCompleted)
                    {
                        goto TR_0005;
                    }
                    else
                    {
                        this.<>1__state = num = 1;
                        this.<>u__1 = awaiter2;
                        this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<OnDisconnectedAsync>d__5>(ref awaiter2, ref this);
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
        private struct <QuadroMens>d__8 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public NotificacoesHub <>4__this;
            public string para;
            public string mens;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                NotificacoesHub hub = this.<>4__this;
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
                        awaiter = ClientProxyExtensions.SendAsync(hub.get_Clients().Client(this.para), "quadromens", hub.get_Context().get_ConnectionId(), this.para.Replace("@", "").Replace(".", ""), this.mens, token).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<QuadroMens>d__8>(ref awaiter, ref this);
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

        [CompilerGenerated]
        private struct <Quem>d__6 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public string idusu;
            public NotificacoesHub <>4__this;
            public string status;
            private NotificacoesHub.<>c__DisplayClass6_1 <>8__1;
            private NotificacoesHub.<>c__DisplayClass6_0 <>8__2;
            private TaskAwaiter<int> <>u__1;
            private TaskAwaiter <>u__2;

            private void MoveNext()
            {
                int num = this.<>1__state;
                NotificacoesHub hub = this.<>4__this;
                try
                {
                    if (num > 3)
                    {
                        this.<>8__2 = new NotificacoesHub.<>c__DisplayClass6_0();
                        this.<>8__2.idusu = this.idusu;
                    }
                    try
                    {
                        ParameterExpression expression;
                        TaskAwaiter<int> awaiter;
                        CancellationToken token;
                        TaskAwaiter<int> awaiter2;
                        TaskAwaiter<int> awaiter3;
                        TaskAwaiter awaiter4;
                        switch (num)
                        {
                            case 0:
                                awaiter = this.<>u__1;
                                this.<>u__1 = new TaskAwaiter<int>();
                                this.<>1__state = num = -1;
                                break;

                            case 1:
                                awaiter2 = this.<>u__1;
                                this.<>u__1 = new TaskAwaiter<int>();
                                this.<>1__state = num = -1;
                                goto TR_000E;

                            case 2:
                                awaiter3 = this.<>u__1;
                                this.<>u__1 = new TaskAwaiter<int>();
                                this.<>1__state = num = -1;
                                goto TR_000B;

                            case 3:
                                awaiter4 = this.<>u__2;
                                this.<>u__2 = new TaskAwaiter();
                                this.<>1__state = num = -1;
                                goto TR_0008;

                            default:
                            {
                                this.<>8__1 = new NotificacoesHub.<>c__DisplayClass6_1();
                                expression = Expression.Parameter((Type) typeof(UsuarioApp), "x");
                                ParameterExpression[] expressionArray1 = new ParameterExpression[] { expression };
                                this.<>8__1._usu = Queryable.FirstOrDefault<UsuarioApp>(Queryable.Where<UsuarioApp>(hub._context.get_Users(), Expression.Lambda<Func<UsuarioApp, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(IdentityUser<string>.get_Id, IdentityUser<string>)), (Expression) Expression.Field((Expression) Expression.Constant(this.<>8__2, (Type) typeof(NotificacoesHub.<>c__DisplayClass6_0)), fieldof(NotificacoesHub.<>c__DisplayClass6_0.idusu))), expressionArray1)));
                                tblHubCliente cliente1 = new tblHubCliente();
                                cliente1.CnxId = hub.get_Context().get_ConnectionId();
                                cliente1.Email = this.<>8__1._usu.get_Email();
                                cliente1.Status = this.status;
                                cliente1.UsuarioAppId = this.<>8__1._usu.get_Id();
                                tblHubCliente cliente = cliente1;
                                hub._context.tblHubClientes.Add(cliente);
                                token = new CancellationToken();
                                awaiter = hub._context.SaveChangesAsync(token).GetAwaiter();
                                if (awaiter.IsCompleted)
                                {
                                    break;
                                }
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, NotificacoesHub.<Quem>d__6>(ref awaiter, ref this);
                                return;
                            }
                        }
                        awaiter.GetResult();
                        expression = Expression.Parameter((Type) typeof(tblUsuSalaVIP), "x");
                        ParameterExpression[] expressionArray2 = new ParameterExpression[] { expression };
                        IQueryable<tblUsuSalaVIP> queryable = Queryable.Where<tblUsuSalaVIP>(hub._context.tblUsuSalaVIPs, Expression.Lambda<Func<tblUsuSalaVIP, bool>>((Expression) Expression.Equal((Expression) Expression.Property((Expression) expression, (MethodInfo) methodof(tblUsuSalaVIP.get_UsuarioAppId)), (Expression) Expression.Property((Expression) Expression.Field((Expression) Expression.Constant(this.<>8__1, (Type) typeof(NotificacoesHub.<>c__DisplayClass6_1)), fieldof(NotificacoesHub.<>c__DisplayClass6_1._usu)), (MethodInfo) methodof(IdentityUser<string>.get_Id, IdentityUser<string>))), expressionArray2));
                        hub._context.tblUsuSalaVIPs.RemoveRange((IEnumerable<tblUsuSalaVIP>) queryable);
                        token = new CancellationToken();
                        awaiter2 = hub._context.SaveChangesAsync(token).GetAwaiter();
                        if (!awaiter2.IsCompleted)
                        {
                            this.<>1__state = num = 1;
                            this.<>u__1 = awaiter2;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, NotificacoesHub.<Quem>d__6>(ref awaiter2, ref this);
                            return;
                        }
                        goto TR_000E;
                    TR_0008:
                        awaiter4.GetResult();
                        this.<>8__1 = null;
                        goto TR_0002;
                    TR_0009:
                        token = new CancellationToken();
                        awaiter4 = ClientProxyExtensions.SendAsync(hub.get_Clients().get_All(), "quemsoueu", hub.get_Context().get_ConnectionId(), this.<>8__2.idusu, this.<>8__1._usu.get_Id(), this.<>8__1._usu.Nome + " " + this.<>8__1._usu.Sobrenome, this.status, token).GetAwaiter();
                        if (awaiter4.IsCompleted)
                        {
                            goto TR_0008;
                        }
                        else
                        {
                            this.<>1__state = num = 3;
                            this.<>u__2 = awaiter4;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<Quem>d__6>(ref awaiter4, ref this);
                        }
                        return;
                    TR_000B:
                        awaiter3.GetResult();
                        goto TR_0009;
                    TR_000E:
                        awaiter2.GetResult();
                        if (this.status.ToLower().Trim() != "entrou")
                        {
                            goto TR_0009;
                        }
                        else
                        {
                            tblUsuSalaVIP avip1 = new tblUsuSalaVIP();
                            avip1.CnxId = hub.get_Context().get_ConnectionId();
                            avip1.UsuarioAppId = this.<>8__1._usu.get_Id();
                            tblUsuSalaVIP avip = avip1;
                            hub._context.tblUsuSalaVIPs.Add(avip);
                            token = new CancellationToken();
                            awaiter3 = hub._context.SaveChangesAsync(token).GetAwaiter();
                            if (awaiter3.IsCompleted)
                            {
                                goto TR_000B;
                            }
                            else
                            {
                                this.<>1__state = num = 2;
                                this.<>u__1 = awaiter3;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, NotificacoesHub.<Quem>d__6>(ref awaiter3, ref this);
                            }
                        }
                        return;
                    }
                    catch (Exception exception1)
                    {
                        string message = exception1.Message;
                    }
                }
                catch (Exception exception2)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception2);
                    return;
                }
            TR_0002:
                this.<>1__state = -2;
                this.<>t__builder.SetResult();
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <Teclando>d__10 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public NotificacoesHub <>4__this;
            public string de;
            public string para;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                NotificacoesHub hub = this.<>4__this;
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
                        awaiter = ClientProxyExtensions.SendAsync(hub.get_Clients().get_All(), "teclando", this.de, this.para, token).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<Teclando>d__10>(ref awaiter, ref this);
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

        [CompilerGenerated]
        private struct <Teste>d__11 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder <>t__builder;
            public NotificacoesHub <>4__this;
            public string cnxpara;
            public string de;
            public string para;
            public string mens;
            public string cnxde;
            private TaskAwaiter <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                NotificacoesHub hub = this.<>4__this;
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
                        awaiter = ClientProxyExtensions.SendAsync(hub.get_Clients().Client(this.cnxpara), "teste", this.de, this.para, this.mens, this.cnxde, this.cnxpara, token).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, NotificacoesHub.<Teste>d__11>(ref awaiter, ref this);
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

