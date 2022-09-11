// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");
// Greedy algorithms . 

// Activity selcetion problem Or Maximum Disjoint interval . 
//  Maximum Meetings in One Room   -- https://practice.geeksforgeeks.org/problems/maximum-meetings-in-one-room/1?utm_source=youtube&utm_medium=collab_anujbhaiya_description&utm_campaign=maximum-meetings-in-one-room

/*int[] s = { 1, 4, 12, 15, 7 };
int[] f = { 13, 6, 14, 19, 13 };
Console.WriteLine("maxMetting : " + maxMettings(s.Length, s, f));
*/
List<int> maxMettings(int n,int[] s,int[] f) 
{
   List<int> ans = new List<int>();
   int[ , ] a = new int[n, 3];  // We have 3 coloum : 1st - index,2nd - Start time ,3rd -End time of event ,N row for available inout data . 
    for (int i = 0; i < n; i++)
    {
        a[i, 0] = i + 1;
        a[i, 1] = s[i];
        a[i, 2] = f[i]; 
    }
    // a = Sort2dArray(a);// Sory array based on end time of Event. 
    int r = a[0, 2];  // putting end time of first event . 
    ans.Add(a[0, 0]);
    for (int i = 0; i < n; i++) 
    {
        if (a[i,1]>r)
        {
            ans.Add(a[i,0]);
            r = a[i, 2]; 
        }
    }
    Array.Sort(ans.ToArray());
    return ans;
}
// Wine buying and selling - 
// a[i] < 0 = sell 
// a[i] > 0 = Buy
// total buy = total sell mean sum of given array is = 0
//

int[] a = {5,-4,1,-3,1 };
Console.WriteLine("Lentgh : "+  a.Length);
Console.WriteLine("Operations to sell wine: " + wineSelling(a, a.Length));
int wineSelling(int[] a ,int n) 
{
    int ans = 0;
    int b = 0, s = 0;

    while (b <n && s < n) 
    {
        while (a[b] <= 0) 
        {
            b++;
            if (b == n) return ans;
        }
        while (a[s] >= 0)
        {
            s++;
            if (s == n) return ans;
        }
        if (Math.Abs(a[b]) >=Math.Abs(a[s]))
        {
            ans += Math.Abs(b - s) * Math.Abs(a[s]);
            a[b] += a[s];
            a[s] = 0;
        }
        else 
        {
            ans += Math.Abs(b - s) * Math.Abs(a[b]);
            a[b] = 0;
            a[s] += a[b];
        }
    }

    return ans;
}