import { Col, Row, Space, Typography } from "antd";
import { ReactElement } from "react";
import "./PageHeader.style.css";

const PageHeader = ({
  title,
  actions,
}: {
  title: string;
  actions: ReactElement[];
}) => {
  return (
    <div className="page-header">
      <Row align="top" className="mb-1">
        <Col>
          <div>
            <Typography.Title className="page-header-title" level={4}>
              {title}
            </Typography.Title>
          </div>
        </Col>
        <Col flex="auto" style={{ textAlign: "right" }}>
          <Space>{actions}</Space>
        </Col>
      </Row>
    </div>
  );
};

export default PageHeader;
