#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hangfire.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using System;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Text;
    
    #line 5 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using Hangfire;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using Hangfire.Common;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 8 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 9 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using Hangfire.Dashboard.Resources;
    
    #line default
    #line hidden
    
    #line 10 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using Hangfire.States;
    
    #line default
    #line hidden
    
    #line 11 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using Hangfire.Storage;
    
    #line default
    #line hidden
    
    #line 12 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
    using Hangfire.Storage.Monitoring;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class JobDetailsPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");














            
            #line 14 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
  
    var monitor = Storage.GetMonitoringApi();
    var job = monitor.JobDetails(JobId);
    
    string title = null;

    if (job != null)
    {
        title = job.Job != null ? Html.JobName(job.Job) : null;
        job.History.Add(new StateHistoryDto { StateName = "Created", CreatedAt = job.CreatedAt ?? default(DateTime) });
    }

    title = title ?? Strings.Common_Job;
    Layout = new LayoutPage(title);


            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");


            
            #line 32 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
   Write(Html.JobsSidebar());

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <h1 class=\"page-header\">");


            
            #line 35 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                           Write(title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n\r\n");


            
            #line 37 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
         if (job == null)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"alert alert-warning\">\r\n                ");


            
            #line 40 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
           Write(String.Format(Strings.JobDetailsPage_JobExpired, JobId));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 42 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
        }
        else
        {
            var currentState = job.History[0];
            if (currentState.StateName == ProcessingState.StateName)
            {
                var server = monitor.Servers().FirstOrDefault(x => x.Name == currentState.Data["ServerId"]);
                if (server == null)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div class=\"alert alert-danger\">\r\n                        ");


            
            #line 52 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                   Write(Html.Raw(String.Format(Strings.JobDetailsPage_JobAbortedNotActive_Warning_Html, currentState.Data["ServerId"], Url.To("/servers"))));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");


            
            #line 54 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                }
                else if (server.Heartbeat.HasValue && server.Heartbeat < DateTime.UtcNow.AddMinutes(-1))
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div class=\"alert alert-warning\">\r\n                        ");


            
            #line 58 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                   Write(Html.Raw(String.Format(Strings.JobDetailsPage_JobAbortedWithHeartbeat_Warning_Html, server.Name)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </div>\r\n");


            
            #line 60 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                }
            }

            if (job.ExpireAt.HasValue)
            {

            
            #line default
            #line hidden
WriteLiteral("                <div class=\"alert alert-info\">\r\n                    ");


            
            #line 66 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
               Write(Html.Raw(String.Format(Strings.JobDetailsPage_JobFinished_Warning_Html, JobHelper.ToTimestamp(job.ExpireAt.Value), job.ExpireAt)));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n");


            
            #line 68 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
            }


            
            #line default
            #line hidden
WriteLiteral("            <div class=\"job-snippet\">\r\n                <div class=\"job-snippet-co" +
"de\">\r\n                    <pre><code><span class=\"comment\">// ");


            
            #line 72 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                   Write(Strings.JobDetailsPage_JobId);

            
            #line default
            #line hidden
WriteLiteral(": ");


            
            #line 72 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                                                  Write(Html.JobId(JobId.ToString(), false));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n");


            
            #line 73 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
Write(JobMethodCallRenderer.Render(job.Job));

            
            #line default
            #line hidden
WriteLiteral("\r\n</code></pre>\r\n                </div>\r\n\r\n");


            
            #line 77 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                 if (job.Properties.Count > 0)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div class=\"job-snippet-properties\">\r\n                       " +
" <dl>\r\n");


            
            #line 81 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                             foreach (var property in job.Properties.Where(x => x.Key != "Continuations"))
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <dt>");


            
            #line 83 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                               Write(property.Key);

            
            #line default
            #line hidden
WriteLiteral("</dt>\r\n");



WriteLiteral("                                <dd><pre><code>");


            
            #line 84 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                          Write(property.Value);

            
            #line default
            #line hidden
WriteLiteral("</code></pre></dd>\r\n");


            
            #line 85 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </dl>\r\n                    </div>\r\n");


            
            #line 88 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n");


            
            #line 90 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"

            if (job.Properties.TryGetValue("Continuations", out var serializedContinuations))
            {
                var continuations = ContinuationsSupportAttribute.DeserializeContinuations(serializedContinuations);

                if (continuations.Count > 0)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <h3>");


            
            #line 97 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                   Write(Strings.Common_Continuations);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n");



WriteLiteral("                    <div class=\"table-responsive\">\r\n                        <tabl" +
"e class=\"table\">\r\n                            <thead>\r\n                         " +
"   <tr>\r\n                                <th class=\"min-width\">");


            
            #line 102 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                 Write(Strings.Common_Id);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                <th class=\"min-width\">");


            
            #line 103 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                 Write(Strings.Common_Condition);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                <th class=\"min-width\">");


            
            #line 104 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                 Write(Strings.Common_State);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                <th>");


            
            #line 105 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                               Write(Strings.Common_Job);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                                <th class=\"align-right\">");


            
            #line 106 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                   Write(Strings.Common_Created);

            
            #line default
            #line hidden
WriteLiteral("</th>\r\n                            </tr>\r\n                            </thead>\r\n " +
"                           <tbody>\r\n");


            
            #line 110 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                             foreach (var continuation in continuations)
                            {
                                JobData jobData;

                                using (var connection = Storage.GetConnection())
                                {
                                    jobData = connection.GetJobData(continuation.JobId);
                                }


            
            #line default
            #line hidden
WriteLiteral("                                <tr>\r\n");


            
            #line 120 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                     if (jobData == null)
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <td colspan=\"5\"><em>");


            
            #line 122 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                       Write(String.Format(Strings.JobDetailsPage_JobExpired, continuation.JobId));

            
            #line default
            #line hidden
WriteLiteral("</em></td>\r\n");


            
            #line 123 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                    }
                                    else
                                    {

            
            #line default
            #line hidden
WriteLiteral("                                        <td class=\"min-width\">");


            
            #line 126 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                         Write(Html.JobIdLink(continuation.JobId));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");



WriteLiteral("                                        <td class=\"min-width\"><code>");


            
            #line 127 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                               Write(continuation.Options.ToString("G"));

            
            #line default
            #line hidden
WriteLiteral("</code></td>\r\n");



WriteLiteral("                                        <td class=\"min-width\">");


            
            #line 128 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                         Write(Html.StateLabel(jobData.State));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");



WriteLiteral("                                        <td class=\"word-break\">");


            
            #line 129 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                          Write(Html.JobNameLink(continuation.JobId, jobData.Job));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");



WriteLiteral("                                        <td class=\"align-right\">");


            
            #line 130 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                           Write(Html.RelativeTime(jobData.CreatedAt));

            
            #line default
            #line hidden
WriteLiteral("</td>\r\n");


            
            #line 131 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                    }

            
            #line default
            #line hidden
WriteLiteral("                                </tr>\r\n");


            
            #line 133 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                            </tbody>\r\n                        </table>\r\n         " +
"           </div>\r\n");


            
            #line 137 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                }
            }


            
            #line default
            #line hidden
WriteLiteral("            <h3>\r\n");


            
            #line 141 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                 if (job.History.Count > 1)
                {

            
            #line default
            #line hidden
WriteLiteral("                    <span class=\"job-snippet-buttons pull-right\">\r\n");


            
            #line 144 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                         if (!IsReadOnly)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button class=\"btn btn-sm btn-default\"\r\n             " +
"                       data-ajax=\"");


            
            #line 147 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                          Write(Url.To("/jobs/actions/requeue/" + JobId));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                    data-loading-text=\"");


            
            #line 148 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                  Write(Strings.Common_Enqueueing);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 149 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                           Write(Strings.JobDetailsPage_Requeue);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </button>\r\n");


            
            #line 151 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                        }

            
            #line default
            #line hidden

            
            #line 152 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                         if (!IsReadOnly)
                        {

            
            #line default
            #line hidden
WriteLiteral("                            <button class=\"btn btn-sm btn-death\"\r\n               " +
"                     data-ajax=\"");


            
            #line 155 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                          Write(Url.To("/jobs/actions/delete/" + JobId));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                    data-loading-text=\"");


            
            #line 156 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                  Write(Strings.Common_Deleting);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                                    data-confirm=\"");


            
            #line 157 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                             Write(Strings.JobDetailsPage_DeleteConfirm);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                                ");


            
            #line 158 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                           Write(Strings.Common_Delete);

            
            #line default
            #line hidden
WriteLiteral("\r\n                            </button>\r\n");


            
            #line 160 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </span>\r\n");


            
            #line 162 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n                ");


            
            #line 164 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
           Write(Strings.JobDetailsPage_State);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </h3>\r\n");


            
            #line 166 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"

            var index = 0;

            foreach (var entry in job.History)
            {
                var accentColor = JobHistoryRenderer.GetForegroundStateColor(entry.StateName);
                var backgroundColor = JobHistoryRenderer.GetBackgroundStateColor(entry.StateName);


            
            #line default
            #line hidden
WriteLiteral("                <div class=\"state-card\" style=\"");


            
            #line 174 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                           Write(index == 0 ? $"border-color: {accentColor}" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                    <h4 class=\"state-card-title\" style=\"");


            
            #line 175 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                    Write(index == 0 ? $"color: {accentColor}" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                        <small class=\"pull-right text-muted\">\r\n");


            
            #line 177 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                             if (index == job.History.Count - 1)
                            {
                                
            
            #line default
            #line hidden
            
            #line 179 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                           Write(Html.RelativeTime(entry.CreatedAt));

            
            #line default
            #line hidden
            
            #line 179 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                                   
                            }
                            else
                            {
                                var duration = Html.ToHumanDuration(entry.CreatedAt - job.History[index + 1].CreatedAt);

                                if (index == 0)
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    ");

WriteLiteral(" ");


            
            #line 187 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                  Write(Html.RelativeTime(entry.CreatedAt));

            
            #line default
            #line hidden
WriteLiteral(" (");


            
            #line 187 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                                       Write(duration);

            
            #line default
            #line hidden
WriteLiteral(")\r\n");


            
            #line 188 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                }
                                else
                                {

            
            #line default
            #line hidden
WriteLiteral("                                    ");

WriteLiteral(" ");


            
            #line 191 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                  Write(Html.MomentTitle(entry.CreatedAt, duration));

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 192 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                }
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </small>\r\n\r\n                        ");


            
            #line 196 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                   Write(entry.StateName);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </h4>\r\n\r\n");


            
            #line 199 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                     if (!String.IsNullOrWhiteSpace(entry.Reason))
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <p class=\"state-card-text text-muted\">");


            
            #line 201 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                         Write(entry.Reason);

            
            #line default
            #line hidden
WriteLiteral("</p>\r\n");


            
            #line 202 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 204 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                      
                        var rendered = Html.RenderHistory(entry.StateName, entry.Data);
                    

            
            #line default
            #line hidden
WriteLiteral("\r\n");


            
            #line 208 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                     if (rendered != null)
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div class=\"state-card-body\" style=\"");


            
            #line 210 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                                                        Write(index == 0 ? $"background-color: {backgroundColor}" : null);

            
            #line default
            #line hidden
WriteLiteral("\">\r\n                            ");


            
            #line 211 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                       Write(rendered);

            
            #line default
            #line hidden
WriteLiteral("\r\n                        </div>\r\n");


            
            #line 213 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                </div>\r\n");


            
            #line 215 "..\..\Dashboard\Pages\JobDetailsPage.cshtml"

                index++;
            }
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>");


        }
    }
}
#pragma warning restore 1591
