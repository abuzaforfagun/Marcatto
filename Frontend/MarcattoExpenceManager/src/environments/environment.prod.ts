const rootAPI = 'http://www.marcatto.projects.fagun.me/api';

export const environment = {
  production: true
};


export const API = {
  bank: {
    getAll: `${rootAPI}/bank/`,
    add: `${rootAPI}/bank`,
    terminate: `${rootAPI}/bank`,
  },
  paymentOpiton: {
    getAll: `${rootAPI}/paymentoptions`
  }
};
