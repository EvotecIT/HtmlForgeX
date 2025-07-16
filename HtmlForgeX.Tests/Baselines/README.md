# Baseline Screenshots

This folder stores reference images used by Playwright layout tests.

If a baseline image is missing, the integration tests will create it automatically. To intentionally update an existing baseline, set the `UPDATE_BASELINES` environment variable to `true` when running the tests. The test will overwrite the files in this directory with new screenshots.
