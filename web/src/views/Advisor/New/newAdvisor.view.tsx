import { observer } from "mobx-react";
import { useNavigate } from "react-router-dom";
import "./newAdvisor.style.css";
import { Button, Form, Input, Space, message } from "antd";
import PageHeader from "../../../components/PageHeader";
import NewAdvisorViewModel from "./newAdvisor.viewModel";
import InputMask from "react-input-mask";
import { useEffect } from "react";
import { autorun } from "mobx";

const NewAdvisorView = observer(
  ({ viewModel }: { viewModel: NewAdvisorViewModel }) => {
    const navigate = useNavigate();
    const [form] = Form.useForm();

    useEffect(() => {
      viewModel.clearAll();
    }, [viewModel]);

    useEffect(() =>
      autorun(() => {
        form.setFieldsValue(viewModel.advisor);
      })
    );

    return (
      <div className="page">
        <PageHeader title="New Advisor" actions={[]} />
        <div className="form-content">
          <div className="form-card">
            <Form
              labelCol={{ span: 4 }}
              wrapperCol={{ span: 19 }}
              form={form}
              name="new-advisor"
              initialValues={viewModel.advisor}
              onValuesChange={(changedValues) =>
                viewModel.updateAdvisorDetails(changedValues)
              }
              onFinishFailed={() => {
                message.warning("Please fill in the highlighted fields");
              }}
              onFinish={() => viewModel.saveAdvisor(() => navigate("/"))}
            >
              <Form.Item
                name="name"
                label="Name"
                rules={[{ required: true, message: "Please input a name" }]}
              >
                <Input maxLength={255} />
              </Form.Item>
              <Form.Item
                name="socialInsuranceNumber"
                label="SIN"
                rules={[
                  {
                    required: true,
                    max: 9,
                    min: 9,
                    message: "Please input a 9 digit SIN",
                  },
                ]}
              >
                <InputMask
                  mask="999 999 999"
                  className="ant-input ant-input-outlined css-dev-only-do-not-override-17seli4"
                />
              </Form.Item>
              <Form.Item name="address" label="Address">
                <Input maxLength={255} />
              </Form.Item>
              <Form.Item
                name="phoneNumber"
                label="Phone"
                rules={[
                  {
                    required: false,
                    max: 8,
                    min: 8,
                    message: "Please enter a 8 digit phone number",
                  },
                ]}
              >
                <InputMask
                  mask="9-999-9999"
                  className="ant-input ant-input-outlined css-dev-only-do-not-override-17seli4"
                />
              </Form.Item>
              <Form.Item wrapperCol={{ offset: 4, span: 19 }}>
                <Space direction="horizontal" style={{ float: "right" }}>
                  <Button onClick={() => navigate("/")} type="default">
                    Cancel
                  </Button>
                  <Button onClick={() => form.submit()} type="primary">
                    Save
                  </Button>
                </Space>
              </Form.Item>
            </Form>
          </div>
        </div>
      </div>
    );
  }
);

export default NewAdvisorView;
