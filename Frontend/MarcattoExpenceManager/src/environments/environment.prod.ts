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
  },
  income: {
    add: `${rootAPI}/income`,
    getAll: `${rootAPI}/income/`,
    getByDate: `${rootAPI}/income/date/`
  },
  expense: {
    add: `${rootAPI}/expense/`,
    getAll: `${rootAPI}/expense/`,
    getByDate: `${rootAPI}/expense/date/`
  },
  dashboard: {
    summery: `${rootAPI}/dashboard/`
  }
};
