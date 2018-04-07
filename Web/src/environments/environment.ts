import env from './.env'; 
export const environment = {
  production: false,
  version: env.npm_package_version,
  serverUrl: 'http://localhost:24606/api',
  defaultLanguage: 'rus-RUS',
  supportedLanguages: [
    'rus-RUS',
    'br-BLR'
  ]
};
