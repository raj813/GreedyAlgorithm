// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;
using System.Collections;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Hello, World!");


// Greedy algorithms . 

// Activity selcetion problem Or Maximum Disjoint interval . 
//  Maximum Meetings in One Room   -- https://practice.geeksforgeeks.org/problems/maximum-meetings-in-one-room/1?utm_source=youtube&utm_medium=collab_anujbhaiya_description&utm_campaign=maximum-meetings-in-one-room
/*
int[] s = { 1, 4, 12, 15, 7 };
int[] f = { 13, 6, 14, 19, 13 };
//Console.WriteLine("maxMetting : " + maxMettings(s.Length, s, f));
*/

static void print2dArray(int[,] arrip)
{
    int x = arrip.GetLength(0);
    int z = arrip.GetLength(1);
    Console.WriteLine("Print start");
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < z; j++)
        {
            //Console.WriteLine("arrip[{0},{1}] :{2}", i, j, arrip[i, j]);
            Console.Write("{0}  ", arrip[i, j]);
        }
        Console.WriteLine();
        //  Console.WriteLine("arrip[{0},{1}] :{2} ,arrip[{0},{3}] :{4}", i,0, arrip[i, 0],1, arrip[i, 1]);
    }
    Console.WriteLine("Print end");

}
List<int> maxMettings(int n,int[] s,int[] f) 
{
   List<int> ans = new List<int>();
   int[,] a = new int[n, 3];  // We have 3 coloum : 1st - index,2nd - Start time ,3rd -End time of event ,N row for available inout data . 
    for (int i = 0; i < n; i++)
    {
        a[i, 0] = i + 1;
        a[i, 1] = s[i];
        a[i, 2] = f[i]; 
    }
    int[][] b = new int[n][];
    
    for (int i = 0; i < n; i++) 
    {
        b[i][0] =  s[i] ;
        b[i][1] =  f[i];
    }
    //Array.Sort(a, (x,y)=> { return x[2] - y[2]; });// Sory array based on end time of Event. 
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

/*int[] a = {5,-4,1,-3,1 };
Console.WriteLine("Lentgh : "+  a.Length);
Console.WriteLine("Operations to sell wine: " + wineSelling(a, a.Length));*/
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

//Minimum plateforms 
/*
int[] a = { 0900, 0905, 0950, 1100, 1500, 1800 };
int[] d = { 0910, 1900, 1120, 1130, 1900, 2000 };
Console.WriteLine("Find minimum plateorms : " + findPlateform(a, d, a.Length));    */


int findPlateform(int[] a,int[] d ,int n) 
{
    Array.Sort(a);
    Array.Sort(d);
    int count = 0;
    int ans = 0;
    int i = 0, j = 0;  //two pointer ,i go in arraival and j for departure.
    while (i < n) // As arraival willreach to end soon. 
    {
        if (a[i] <= d[j])
        {
            count++;
            ans = Math.Max(ans, count);
            i++;
        }
        //else if (a[i] > d[j]) 
        else{
            count--;
            j++;
        }
    }
    return ans;
}


//*
//Shop in the candy store -Find minimum spedning and max spending . To  buy all candy
//with all candy you receive int k which allow to get some free candy.
//*//

int[] shopCandy(int[] a,int n ,int k) 
{
    int[] ans = new int[2];
    Array.Sort(a);
    //in greedy  approch to find min we buy cheap  candy and take costly as free. 
    int buy = 0;
    int free = n - 1;
    
    while (buy <= free) 
    {
        ans[0] = ans[0]+ a[buy];
        buy++;
        free = free - k;
    }

    buy = n - 1;
    free = 0;
    while (free <= buy) 
    {
        ans[1] = ans[1]+ a[buy];
        buy--;  
        free = free + k;
    }
    return ans;
}

//*   Survive on iseland 
//  N = max food can be buy,
//  M  = food/day to  survuve .
//  s= days to  survive
//  Shop is closed on sundays . Everytime you start at Tuesday.
//  return total no of buying ,if not able to survive return -1.*//

// Console.WriteLine("Food buying day : " + SurvivrIseland(20,30,10));
int SurvivrIseland(int n,int m ,int s)                  
{
    int ans = 0;
    int sundays = s / 7;
    int buyingdays = s - sundays;

    int maxfood = s * m;
    if (maxfood % n == 0) {ans = maxfood/n; }
    else { return (maxfood / n + 1); }

    if (ans <= buyingdays) { return ans; }
    else { return -1; }
    
}

//*
//Reverse a string .
//from . *//
string s = "iam.like.this.program.very.much";
Console.WriteLine(s);
s = revWords(s);
Console.WriteLine(s); 
string revString(string s) 
{
    char[] temp = s.ToCharArray();
    Array.Reverse(temp);
    s = new string(temp);   
    return s;
}
string revWords(string s) 
{
    string ans = "";
    string temp = "";
    for (int i = s.Length -1;i>=0 ; i--)
    {
        if (s[i] == '.')
        {
            temp = revString(temp);
            ans = ans + temp + '.';
            temp = "";
        }
        else
        {
            temp += (s[i]);
        }
    }
       
        ans = ans + revString(temp);
    
        return ans;
    
}





