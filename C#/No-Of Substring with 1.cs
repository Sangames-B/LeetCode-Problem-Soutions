public class Solution {
    const int MOD = 1000000007;

    public int NumSub(string s) {
        long result = 0;
        int count = 0;

        // Traverse the string
        foreach (char c in s) {
            if (c == '1') {
                // Extend the current streak of 1's
                count++;
                result += count; // add all substrings ending here
            } else {
                // Reset streak when we hit a '0'
                count = 0;
            }

            if (result >= MOD) result %= MOD;
        }

        return (int)(result % MOD);
    }
}
