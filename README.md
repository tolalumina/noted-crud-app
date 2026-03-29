<div align="center" style="background: linear-gradient(135deg, #6a11cb 0%, #2575fc 100%); padding: 30px; border-radius: 15px; color: white; font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;">
  <h1>📝 Notes API (Backend)</h1>
  <p style="font-size: 1.2em; opacity: 0.9;">A high-performance RESTful service built with ASP.NET Core & Dapper</p>
  <div style="margin-top: 15px;">
    <span style="background: rgba(255,255,255,0.2); padding: 5px 12px; border-radius: 20px; font-size: 0.8em; margin: 5px;">.NET 8.0</span>
    <span style="background: rgba(255,255,255,0.2); padding: 5px 12px; border-radius: 20px; font-size: 0.8em; margin: 5px;">SQL Server</span>
    <span style="background: rgba(255,255,255,0.2); padding: 5px 12px; border-radius: 20px; font-size: 0.8em; margin: 5px;">Dapper</span>
  </div>
</div>

<br />

<h2 style="border-bottom: 2px solid #2575fc; padding-bottom: 5px; color: #333;">📌 Overview</h2>
<p>
  The <b>Notes API</b> is a production-ready backend designed for speed and simplicity. 
  By using <b>Dapper</b> as a Micro-ORM, it achieves near-native SQL performance while maintaining 
  clean, readable C# code. Perfect for integration with modern frontends like <b>Vue.js</b> or <b>React</b>.
</p>

---

<h2 style="border-bottom: 2px solid #2575fc; padding-bottom: 5px; color: #333;">🚀 Tech Stack</h2>

| Component | Technology |
| :--- | :--- |
| **Framework** | <code style="color: #6a11cb;">ASP.NET Core Web API</code> |
| **Language** | <code style="color: #2575fc;">C# 12</code> |
| **ORM** | <code style="color: #6a11cb;">Dapper</code> |
| **Database** | <code style="color: #2575fc;">SQL Server</code> |

---

<h2 style="border-bottom: 2px solid #2575fc; padding-bottom: 5px; color: #333;">📡 API Endpoints</h2>

<table style="width: 100%; border-collapse: collapse;">
  <thead>
    <tr style="background-color: #f8f9fa;">
      <th style="padding: 12px; text-align: left; border: 1px solid #dee2e6;">Action</th>
      <th style="padding: 12px; text-align: left; border: 1px solid #dee2e6;">Method</th>
      <th style="padding: 12px; text-align: left; border: 1px solid #dee2e6;">Endpoint</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td style="padding: 12px; border: 1px solid #dee2e6;">Get All Notes</td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><b style="color: #28a745;">GET</b></td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><code>/api/notes</code></td>
    </tr>
    <tr>
      <td style="padding: 12px; border: 1px solid #dee2e6;">Get by ID</td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><b style="color: #28a745;">GET</b></td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><code>/api/notes/{id}</code></td>
    </tr>
    <tr>
      <td style="padding: 12px; border: 1px solid #dee2e6;">Create Note</td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><b style="color: #007bff;">POST</b></td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><code>/api/notes</code></td>
    </tr>
    <tr>
      <td style="padding: 12px; border: 1px solid #dee2e6;">Update Note</td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><b style="color: #ffc107;">PUT</b></td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><code>/api/notes/{id}</code></td>
    </tr>
    <tr>
      <td style="padding: 12px; border: 1px solid #dee2e6;">Delete Note</td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><b style="color: #dc3545;">DELETE</b></td>
      <td style="padding: 12px; border: 1px solid #dee2e6;"><code>/api/notes/{id}</code></td>
    </tr>
  </tbody>
</table>

<br />

### 📤 Request Body (POST/PUT)
```json
{
  "title": "Strategy Meeting",
  "content": "Discuss the new API deployment timeline."
}
