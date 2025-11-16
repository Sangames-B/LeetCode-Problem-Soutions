class Solution {
    const int MOD = 1000000007; // We always take results modulo 1e9+7

    public int CountMonotonicPairs(int[] nums) {
        int n = nums.Length;
        int maxVal = 0;
        foreach (int x in nums) maxVal = Math.Max(maxVal, x);

        // dp[i][x] = number of valid ways if arr1[i] = x
        int[,] dp = new int[n, maxVal + 1];

        // Base case: at index 0, arr1[0] can be any value from 0..nums[0]
        // Each choice is valid because there's no previous element to compare
        for (int x = 0; x <= nums[0]; x++) {
            dp[0, x] = 1;
        }

        // Fill DP table for each index i
        for (int i = 1; i < n; i++) {
            // Prefix sums to quickly calculate ranges of dp[i-1][y]
            int[] prefix = new int[maxVal + 2];

            // Build prefix sums from dp[i-1]
            for (int y = 0; y <= nums[i - 1]; y++) {
                prefix[y + 1] = (prefix[y + 1] + dp[i - 1, y]) % MOD;
            }
            for (int y = 1; y <= maxVal; y++) {
                prefix[y] = (prefix[y] + prefix[y - 1]) % MOD;
            }

            // Now compute dp[i][x] for each possible arr1[i] = x
            for (int x = 0; x <= nums[i]; x++) {
                // Condition 1: arr1[i-1] ≤ arr1[i] (non-decreasing arr1)
                // Condition 2: arr2[i-1] ≥ arr2[i] (non-increasing arr2)
                // Recall arr2[k] = nums[k] - arr1[k]

                // Rearranging condition 2 gives:
                // arr1[i-1] ≥ nums[i-1] - (nums[i] - x)
                int minY = 0;
                int maxY = Math.Min(x, nums[i - 1] - nums[i] + x);
                if (maxY >= 0) {
                maxY = Math.Min(maxY, nums[i - 1]);
                dp[i, x] = (prefix[maxY + 1] - prefix[minY] + MOD) % MOD;
                }

            }
        }

        // Final answer = sum of all dp[n-1][x] for x in [0..nums[n-1]]
        long ans = 0;
        for (int x = 0; x <= nums[n - 1]; x++) {
            ans = (ans + dp[n - 1, x]) % MOD;
        }
        return (int)ans;
    }

    // Quick test
    static void Main() {
        var sol = new Solution();
        Console.WriteLine(sol.CountMonotonicPairs(new int[] { 2, 3, 2 })); // Output: 4
        Console.WriteLine(sol.CountMonotonicPairs(new int[] { 5, 5, 5, 5 })); // Output: 126
    }
}