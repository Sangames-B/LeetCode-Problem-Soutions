class Solution {
public:
    int numSub(string s) {
        const int MOD = 1000000007;
        long long result = 0;
        int count = 0;

        for (char c : s) {
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
};
