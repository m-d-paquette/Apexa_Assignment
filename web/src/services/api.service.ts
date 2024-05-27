// all api routes
export default class APIService {
  getAdvisors = () => "Advisors";
  getAdvisor = (id: number | string) => "Advisors/" + id;
  deleteAdvisor = (id: number) => "Advisors/" + id + "/Delete";
}
