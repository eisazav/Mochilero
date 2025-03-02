// apiService.js
const service = {};

// THIS IS THE VARIABLE YOU MUST CHANGE IF THE PORT IS DIFFERENT
//----------------------------------------------------------------------
const baseUrl = 'http://localhost:5299/';
//----------------------------------------------------------------------

service.calculate = async (input) => {
  const url = `${baseUrl}calculate`;
  const options = {
    method: 'post',
    ejectUnauthorized: false,
    body: JSON.stringify(input),
    headers: { 'Content-Type': 'application/json' },
  };
  const answer = await makeRequest(url, options);
  console.log(url);
  console.log(options);
  return answer;
};

const makeRequest = async (url, options) => {
  try {
    const fetch = (await import('node-fetch')).default;
    const { showLog } = await import('./helpers.js');
    const resp = await fetch(url, options || {});
    if (!resp.ok) {
      showLog('REQUEST URL: ' + url, { options: options, resp: resp });
      return { err: 'Error obtaining data' };
    }
    const json = await resp.json();
    return { data: json };
  } catch (error) {
    const { showLog } = await import('./helpers.js');
    showLog('REQUEST URL: ' + url, error);
    return { err: 'Error obtaining data', err_service: error };
  }
};

module.exports = service;