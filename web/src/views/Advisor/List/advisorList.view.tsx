import { observer } from "mobx-react";
import { useEffect } from "react";
import { Link, useNavigate } from "react-router-dom";
import AdvisorListViewModel from "./advisorList.viewModel";
import "./advisorList.style.css";
import { Advisor } from "../../../models/advisor";
import { TableProps, Tag, Space, Table, Modal, Button, Empty } from "antd";
import PageHeader from "../../../components/PageHeader";

const AdvisorListView = observer(
  ({ viewModel }: { viewModel: AdvisorListViewModel }) => {
    const navigate = useNavigate();

    useEffect(() => {
      viewModel.getAdvisors();
    }, [viewModel]);

    const formatPhone = (value: string) => {
      if (!value) return value;
      const phoneNumber = value.replace(/[^\d]/g, "");
      return `${phoneNumber.slice(0, 1)}-${phoneNumber.slice(
        1,
        4
      )}-${phoneNumber.slice(4, 8)}`;
    };

    const formatSIN = (value: string) => {
      if (!value) return value;
      const sin = value.replace(/[^\d]/g, "");
      return `${sin.slice(0, 3)} ${sin.slice(3, 6)} ${sin.slice(6, 9)}`;
    };

    const columns: TableProps<Advisor>["columns"] = [
      {
        title: "Name",
        dataIndex: "name",
        key: "name",
      },
      {
        title: "SIN",
        dataIndex: "socialInsuranceNumber",
        key: "sin",
        render: (text: string) => <span>{formatSIN(text)}</span>,
      },
      {
        title: "Address",
        dataIndex: "address",
        key: "address",
      },
      {
        title: "Phone",
        dataIndex: "phoneNumber",
        key: "phone",
        render: (text: string) => <span>{formatPhone(text)}</span>,
      },
      {
        title: "Health Status",
        key: "healthStatus",
        dataIndex: "healthStatus",
        render: (status) => {
          const color =
            status === 1 ? "green" : status === 2 ? "goldenrod" : "firebrick";
          return (
            <div
              className="status-indicator"
              style={{ backgroundColor: color }}
            />
          );
        },
      },
      {
        title: "Action",
        key: "action",
        render: (_, record) => (
          <Space size="middle">
            <Link
              to={`/advisor/details/${record.id}`}
              onClick={(e) => {
                e.preventDefault();
                navigate(`/advisor/details/${record.id}`);
              }}
            >
              Details
            </Link>
            <Button
              type="link"
              onClick={() => {
                Modal.confirm({
                  title: "Delete advisor?",
                  content:
                    "Are you sure you want to permanently delete this advisor?",
                  okText: "Delete",
                  onOk: () => viewModel.removeAdvisor(record.id),
                });
              }}
            >
              Delete
            </Button>
          </Space>
        ),
      },
    ];

    return (
      <div className="page">
        <PageHeader
          title="Advisors"
          actions={[
            <Button onClick={() => navigate(`/advisor/new`)} type="primary">
              Add Advisor
            </Button>,
          ]}
        />
        <div className="list-content">
          <Table
            dataSource={viewModel.advisorList}
            columns={columns}
            loading={viewModel.loading}
            locale={{
              emptyText: (
                <Empty
                  image={Empty.PRESENTED_IMAGE_SIMPLE}
                  description="No advisors"
                />
              ),
            }}
          />
        </div>
      </div>
    );
  }
);

export default AdvisorListView;
