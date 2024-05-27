import "./App.css";
import AdvisorListView from "./views/Advisor/List/advisorList.view";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AdvisorListViewModel from "./views/Advisor/List/advisorList.viewModel";
import { Layout } from "antd";
import { Content } from "antd/es/layout/layout";
import HttpService from "./services/http.service";
import APIService from "./services/api.service";
import NewAdvisorViewModel from "./views/Advisor/New/newAdvisor.viewModel";
import NewAdvisorView from "./views/Advisor/New/newAdvisor.view";
import AdvisorDetailsViewModel from "./views/Advisor/Details/advisorDetails.viewModel";
import AdvisorDetailsView from "./views/Advisor/Details/advisorDetails.view";

function App() {
  const httpService = new HttpService();
  const apiService = new APIService();
  const advisorListViewModel = new AdvisorListViewModel(
    httpService,
    apiService
  );
  const newAdvisorViewModel = new NewAdvisorViewModel(httpService, apiService);
  const advisoDetailsrViewModel = new AdvisorDetailsViewModel(
    httpService,
    apiService
  );

  return (
    <BrowserRouter>
      <div className="App">
        <Layout>
          <Content>
            <Routes>
              <Route
                path="/"
                element={<AdvisorListView viewModel={advisorListViewModel} />}
              />
              <Route
                path="/advisor/new"
                element={<NewAdvisorView viewModel={newAdvisorViewModel} />}
              />
              <Route
                path="/advisor/details/:id"
                element={
                  <AdvisorDetailsView viewModel={advisoDetailsrViewModel} />
                }
              />
            </Routes>
          </Content>
        </Layout>
      </div>
    </BrowserRouter>
  );
}

export default App;
