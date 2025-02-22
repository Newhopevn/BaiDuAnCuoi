﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaiDuAn.Models;
namespace BaiDuAn
{
    public partial class GioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NapDuLieu();
            }

        }
        private void NapDuLieu()
        {
            Cart cart = (Cart)Session["CART"];
            if (cart != null)

            {
                //liên kết dữ liệu cho gvGioHang
                gvGioHang.DataSource = cart.Items;
                gvGioHang.DataBind();
                //gán tổng thành tiền cho Label
                lbTongTien.Text = string.Format("Tổng thành tiền: <b> {0: #,##0} đồng </b>",
                cart.Total);
            }

        }
        protected void gvGioHang_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //b1. lấy mã sản phẩm cần xoá khỏi giỏ hàng
            int maxe = int.Parse(gvGioHang.DataKeys[e.RowIndex].Value.ToString());
            //b2.lấy giỏ hàng từ Session
            Cart cart = (Cart)Session["CART"];
            //b3.Xoá sản phẩm khỏi giỏ
            cart.Delete(maxe);
            //b4.Nạp lại dữ liệu cho gvGioHang (làm tươi lại giao diện)
            NapDuLieu();
        }


protected void gvGioHang_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //b1. lấy mã sản phẩm cần xoá khỏi giỏ hàng và số lượng
            int maxe = int.Parse(gvGioHang.DataKeys[e.RowIndex].Value.ToString());
            int soluong =
            int.Parse(((TextBox)gvGioHang.Rows[e.RowIndex].FindControl("txtSoLuong")).Text);
            //b2.lấy giỏ hàng từ Session
            Cart cart = (Cart)Session["CART"];
            //b3.Cập nhật lại số lượng cho sản phẩm
            cart.Update(maxe, soluong);
            //b4.Nạp lại dữ liệu cho gvGioHang (làm tươi lại giao diện)
            NapDuLieu();
        }

        protected void btDatHang_Click(object sender, EventArgs e)
        {

        }
    }
}